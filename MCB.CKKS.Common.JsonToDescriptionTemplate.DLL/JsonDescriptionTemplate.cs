using System.Collections.Generic;
using System.Dynamic;
using Newtonsoft.Json;
using Scriban;
using Scriban.Runtime;
using Microsoft.Extensions.Logging;
using MCB.CKKS.Common.DependencyInjection;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate;

public class JsonDescriptionTemplate : DisposableBase, IJsonDescriptionTemplate, ITransientService<IJsonDescriptionTemplate>
{
    private readonly ILogger? _logger;
    public JsonDescriptionTemplate(ILogger? logger = null)
    {
        _logger = logger;
    }
    /// <summary>
    /// Рендеринг шаблона с использованием JSON-данных (на основе Newtonsoft.Json)
    /// </summary>
    public string RenderJson(string jsonContext, string templateContent)
    {
        // Десериализация JSON в ExpandoObject с помощью Newtonsoft.Json
        var expando = JsonConvert.DeserializeObject<ExpandoObject>(jsonContext);
        // Рекурсивное преобразование в ScriptObject, понятный для Scriban
        var scriptObject = BuildScriptObject(expando);

        // Создание контекста и привязка данных
        var context = new TemplateContext();
        context.PushGlobal(scriptObject);

        // Парсинг и рендеринг шаблона
        var template = Template.Parse(templateContent);
        return template.Render(context);
    }
    /// <summary>
    /// Рендеринг шаблона с использованием JSON-данных (на основе Newtonsoft.Json)
    /// </summary>
    private ScriptObject BuildScriptObject(ExpandoObject expando)
    {

        var dict = (IDictionary<string, object>)expando;
        var scriptObject = new ScriptObject();

        foreach (var kv in dict)
        {
            // Использование правил именования Scriban по умолчанию (например, FirstName -> first_name)
            var renamedKey = StandardMemberRenamer.Rename(kv.Key);

            if (kv.Value is ExpandoObject nestedExpando)
            {
                // Рекурсивная обработка вложенных объектов
                scriptObject.Add(renamedKey, BuildScriptObject(nestedExpando));
            }
            else if (kv.Value is IList<object> list)
            {
                // Обработка массивов (рекурсивное преобразование элементов-объектов внутри массива)
                var newList = new List<object>();
                foreach (var item in list)
                {
                    if (item is ExpandoObject itemExpando)
                        newList.Add(BuildScriptObject(itemExpando));
                    else
                        newList.Add(item);
                }
                scriptObject.Add(renamedKey, newList);
            }
            else
            {
                scriptObject.Add(renamedKey, kv.Value);
            }
        }

        return scriptObject;
    }
}

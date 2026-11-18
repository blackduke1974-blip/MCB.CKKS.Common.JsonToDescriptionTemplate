using MCB.CKKS.Common.DependencyInjection;
using MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate;

/// <summary>
/// Обёртка JsonToDescriptionTemplateApi для регистрации как JavaScript-библиотека в ClearScript.
/// </summary>
public class JsonToDescriptionTemplateLibrary : DisposableBase, IJavaScriptLibrary, ITransientService<IJavaScriptLibrary>
{
    private readonly IJsonDescriptionTemplate _api;

    /// <summary>
    /// Создаёт JsonToDescriptionTemplateLibrary с зависимостями из DI.
    /// </summary>
    public JsonToDescriptionTemplateLibrary(IJsonDescriptionTemplate api)
    {
        _api = api;
        RegisterDisposable(_api);
    }

    /// <summary>
    /// Имя библиотеки (отображается в JS).
    /// </summary>
    public string Name => "jsontodescriptiontemplate";

    /// <summary>
    /// Создаёт экземпляр для использования в JS-скриптах.
    /// </summary>
    public object CreateInstance() => _api;
}

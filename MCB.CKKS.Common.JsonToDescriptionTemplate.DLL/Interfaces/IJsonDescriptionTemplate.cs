using System.Collections.Generic;

namespace MCB.CKKS.Common.JsonToDescriptionTemplate.Interfaces;

public interface IJsonDescriptionTemplate : IDisposable
{
    string RenderJson(string jsonContext, string templateContent);
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TEditor.Abstractions
{
    public interface ITEditor : IDisposable
    {
        Task<TEditorResponse> ShowTEditor(string html, ToolbarBuilder toolbarBuilder = null, bool autoFocusInput = false, Dictionary<string, string> macros = null);
    }
}

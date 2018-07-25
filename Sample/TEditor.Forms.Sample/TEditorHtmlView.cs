using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using TEditor;
using TEditor.Abstractions;
using System.Collections.Generic;

namespace TEditor.Forms.Sample
{
    public class TEditorHtmlView : StackLayout
    {
        //create bindable property, html
        public string Html { get; set; }
        WebView _displayWebView;
        public TEditorHtmlView()
        {
            this.Orientation = StackOrientation.Vertical;
            this.Children.Add(new Button
            {
                Text = "HTML Editor",
                HeightRequest = 100,
                Command = new Command(async (obj) =>
                {
                    await ShowTEditor();
                })
            });
            _displayWebView = new WebView() { HeightRequest = 500 };
            this.Children.Add(_displayWebView);
        }

        async Task ShowTEditor()
        {
            var macrosDic = new Dictionary<string, string>();
            macrosDic.Add("Macro 1", "Value");
            macrosDic.Add("Macro 2", "Value");

            var testMacto = "<div>Patient is now __ s/p __ revision of her reconstructed procedure.&nbsp;</div><div>This was her ___ stage surgery.</div><div><br></div><div><b>OBJECTIVE:</b></div><div><br></div><div><br></div><div><i>Defects:</i></div><div><ul><li>Symmetry: _</li></ul></div><div><ul><li><span style=\"background-color: transparent;\">Implants:&nbsp;</span>_</li></ul></div><div><ul><li><span style=\"background-color: transparent;\">Incisions:&nbsp;</span>_</li></ul></div><div><ul><li>Fat necrosis: _</li></ul></div><div><ul><li>Donor site: _<br></li></ul><div><br></div></div><div><b>General Examination:</b><br></div><div><b><br></b></div><div><b><br></b></div><div><span style=\"background-color: transparent;\"><b>Assessment</b></span><b>:</b><b><br></b></div> ";

            macrosDic.Add("Special Macro", testMacto);


            var test = "<!-- This is an HTML comment --><p>This is a test of the <strong style=\"font-size:20px\">TEditor</strong> by <a title=\"XAM consulting\" href=\"http://www.xam-consulting.com\">XAM consulting</a></p>";

      


            TEditorResponse response = await CrossTEditor.Current.ShowTEditor(test, autoFocusInput: true, macros: macrosDic);
            if (response.IsSave) {
                if (response.HTML != null) {
					_displayWebView.Source = new HtmlWebViewSource() { Html = response.HTML };
                }
            }
        }
    }
}


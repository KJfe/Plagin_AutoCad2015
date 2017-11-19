using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace Plagin_AutoCad.View
{
    public class ParentWindowBindingExtension:MarkupExtension
    {
        public string Path { get; set; }

        public ParentWindowBindingExtension() { }

        public ParentWindowBindingExtension(string path)
        {
            Path = path;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return
                new Binding(Path)
                {
                    RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor)
                    {
                        AncestorType = typeof(Window)
                    }
                }.ProvideValue(serviceProvider);
        }
    }
}

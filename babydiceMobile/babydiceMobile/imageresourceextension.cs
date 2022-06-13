using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Reflection;

namespace babydiceMobile
{
    [ContentProperty(nameof(source))]

    public class imageresourceextension : IMarkupExtension
    {
        public string source { get; set; }
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (source == null)
            {
                return null;
            }

            var imagesource = ImageSource.FromResource(source, typeof(imageresourceextension).GetTypeInfo().Assembly);
            
            return imagesource;
        }
    }
}

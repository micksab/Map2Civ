using System;
using System.ComponentModel;

namespace Map2CivilizationView.UserControls
{

    /// <summary>
    /// Class created just as a workaround for the inability of the designer to directly display a 
    /// user control that inherits form an abstract class that itself inherits from UserControl.
    /// Solution found at http://stackoverflow.com/questions/1620847/how-can-i-get-visual-studio-2008-windows-forms-designer-to-render-a-form-that-imp
    /// </summary>
    /// <typeparam name="TAbstract"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
        : base(TypeDescriptor.GetProvider(typeof(TAbstract)))
        {
        }

        public override Type GetReflectionType(Type objectType, object instance)
        {
            if (objectType == typeof(TAbstract))
                return typeof(TBase);

            return base.GetReflectionType(objectType, instance);
        }

        public override object CreateInstance(IServiceProvider provider, Type objectType, Type[] argTypes, object[] args)
        {
            if (objectType == typeof(TAbstract))
                objectType = typeof(TBase);

            return base.CreateInstance(provider, objectType, argTypes, args);
        }
    }
}

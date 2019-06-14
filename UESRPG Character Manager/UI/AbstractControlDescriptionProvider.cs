using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UESRPG_Character_Manager.UI
{
    /// <summary>
    /// This TypeDescriptionProvider is a weird hack which lets us view abstract-derived UserControls/Forms in the Designer.
    /// </summary>
    /// <typeparam name="TAbstract"></typeparam>
    /// <typeparam name="TBase"></typeparam>
    public class AbstractControlDescriptionProvider<TAbstract, TBase> : TypeDescriptionProvider
    {
        public AbstractControlDescriptionProvider()
            : base( TypeDescriptor.GetProvider( typeof( TAbstract ) ) )
        {
        }

        public override Type GetReflectionType( Type objectType, object instance )
        {
            if ( objectType == typeof( TAbstract ) )
                return typeof( TBase );

            return base.GetReflectionType( objectType, instance );
        }

        public override object CreateInstance( IServiceProvider provider, Type objectType, Type[] argTypes, object[] args )
        {
            if ( objectType == typeof( TAbstract ) )
                objectType = typeof( TBase );

            return base.CreateInstance( provider, objectType, argTypes, args );
        }
    }
}

using System;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;
using UnityEngine;

namespace nyy.System_Extensions.Odin
{
    public class ColoredGroupAttribute : PropertyGroupAttribute
    {
        #region PROPERTIES
        
        public float R, G, B, A;
        
        #endregion
                
        #region IMPLEMENTED FUNCTIONS

        public ColoredGroupAttribute(string path)
            : base(path){}
        
        public ColoredGroupAttribute(string path, float r, float g, float b, float a = 1f)
            : base(path)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }
        
        #endregion  
        
        #region PRIVATE FUNCTIONS
        
        protected override void CombineValuesWith(PropertyGroupAttribute other)
        {
            var otherAttr = (ColoredGroupAttribute)other;

            this.R = Math.Max(otherAttr.R, this.R);
            this.G = Math.Max(otherAttr.G, this.G);
            this.B = Math.Max(otherAttr.B, this.B);
            this.A = Math.Max(otherAttr.A, this.A);
        }
        
        #endregion
    }
    
    public class ColoredGroupAttributeDrawer : OdinGroupDrawer<ColoredGroupAttribute>
    {
        private LocalPersistentContext<bool> isExpanded;

        protected override void Initialize()
        {
            this.isExpanded = this.GetPersistentValue<bool>(
                "ColoredGroupAttributeDrawer.isExpanded",
                true);
        }

        protected override void DrawPropertyLayout(GUIContent label)
        {
            GUIHelper.PushColor(new Color(this.Attribute.R, this.Attribute.G, this.Attribute.B, this.Attribute.A));
            SirenixEditorGUI.BeginBox();
            SirenixEditorGUI.BeginBoxHeader();
            GUIHelper.PopColor(); 
            this.isExpanded.Value = SirenixEditorGUI.Foldout(this.isExpanded.Value, label);
            SirenixEditorGUI.EndBoxHeader();

            if (SirenixEditorGUI.BeginFadeGroup(this, this.isExpanded.Value))
            {
                for (int i = 0; i < this.Property.Children.Count; i++)
                {
                    this.Property.Children[i].Draw();
                }
            }

            SirenixEditorGUI.EndFadeGroup();
            SirenixEditorGUI.EndBox();
        }
    }
}
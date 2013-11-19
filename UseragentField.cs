using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Umbraco.Forms.Data;
using System.Web;
using Umbraco.Forms.Core;

namespace ContourUseragentField
{
    public class UseragentField : Umbraco.Forms.Core.FieldType
    {
        public Umbraco.Forms.Core.Controls.HiddenField hf;
        public List<Object> _value;

         public UseragentField() {
            //Provider
            this.Id = new Guid("b0fb4718-6a38-4d8e-8932-e90baf1abb21");
            this.Name = "Useragent string";
            this.Description = "Retrieves the useragent string from the visitor's browser";
            
             //FieldType
            this.Icon = "useragentstring.png";
            this.DataType = Umbraco.Forms.Core.FieldDataType.String;
           
            _value = new List<object>();
        }


         public override System.Web.UI.WebControls.WebControl Editor
         {
             get
             {
                hf = new Umbraco.Forms.Core.Controls.HiddenField();
                hf.Value = System.Web.HttpContext.Current.Request.UserAgent;
                return hf;
             }
             set
             {
                 base.Editor = value;
             }
         }

         public override List<Object> Values
         {
             get
             {
                 if (hf.Value != "")
                 {
                     _value.Clear();
                     _value.Add(hf.Value);
                 }
                 return _value;
             }
             set
             {
                 _value = value;
             }
         }

         public override string RenderPreview()
         {
             return "<input type=\"hidden\" />";
         }

         public override string RenderPreviewWithPrevalues(List<object> prevalues)
         {
             return RenderPreview();
         }

         public override bool HideLabel
         {
             get
             {
                 return true;
             }

         }

    }
}



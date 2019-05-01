using  Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace razor_inventory.TagHelpers
{
 
    [HtmlTargetElement(Attributes = nameof(Condition))]
    public class ConditionTagHelper: TagHelper

    {
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output) {
            if (!Condition){
                output.SuppressOutput();
            }
        }
    }
}
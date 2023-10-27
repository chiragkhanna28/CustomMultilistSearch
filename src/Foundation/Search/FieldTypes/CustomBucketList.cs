using Microsoft.Extensions.DependencyInjection;
using Sitecore;
using Sitecore.Buckets.Extensions;
using Sitecore.Buckets.FieldTypes;
using Sitecore.Buckets.Util;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Items;
using Sitecore.DependencyInjection;
using Sitecore.Diagnostics;
using Sitecore.Globalization;
using Sitecore.Resources;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Search.FieldTypes
{
    public class CustomBucketList : SearchList
    {
        /// <summary>Gets parameters for JavaScript initialize function</summary>
        protected override string ScriptParameters
        {
            get
            {
                return string.Format("'{0}'", (object)string.Join("', '", (object)this.ID, (object)this.ClientID, (object)this.PageNumber, (object)"/sitecore/shell/Applications/Buckets/Services/Search.ashx", (object)this.Filter, (object)SearchHelper.GetDatabaseUrlParameter("&"), (object)this.TypeHereToSearch, (object)this.Of, (object)this.EnableSetNewStartLocation));
            }
        }

        /// <summary>Render start location input.</summary>
        /// <param name="output">Output stream.</param>
        protected override void RenderStartLocationInput(HtmlTextWriter output)
        {
            if (!this.EnableSetNewStartLocation)
                return;
            base.RenderStartLocationInput(output);
        }

        public override string OutputString(Item item)
        {
            Item bucketItemOrParent = item.GetParentBucketItemOrParent();
            string str = bucketItemOrParent != null ? " - " + bucketItemOrParent.Paths.FullPath : string.Empty;
            return string.Format("{0} ({1}{2})", (object)item.DisplayName, (object)item.TemplateName, (object)str);
        }
    }
}
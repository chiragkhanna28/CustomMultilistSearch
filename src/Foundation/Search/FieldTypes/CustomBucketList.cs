using Sitecore.Buckets.Extensions;
using Sitecore.Buckets.FieldTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data.Items;

namespace Search.FieldTypes
{
    public class CustomBucketList : BucketList
    {
        protected override string ScriptParameters
        {
            get
            {
                return string.Format("'{0}'", (object)string.Join("', '", (object)this.ID, (object)this.ClientID, (object)this.PageNumber, (object)"/sitecore/shell/Applications/Buckets/Services/Search.ashx", (object)this.Filter, (object)SearchHelper.GetDatabaseUrlParameter("&"), (object)this.TypeHereToSearch, (object)this.Of, (object)this.EnableSetNewStartLocation));
            }
        }

        public override string OutputString(Item item)
        {
            Item bucketItemOrParent = item.GetParentBucketItemOrParent();
            string str = bucketItemOrParent != null ? " - " + bucketItemOrParent.Paths.FullPath : string.Empty;
            return string.Format("{0} ({1}{2})", (object)item.DisplayName, (object)item.TemplateName, (object)str);
        }
    }
}
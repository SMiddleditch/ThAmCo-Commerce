using Microsoft.AspNetCore.Mvc.Rendering;

namespace ThAmCo_Commerce.Data.Enums
{
    public enum Category
    {
        Shirt,
        Pants
    }
    public static class ExtensionMethods
    {
        public static IEnumerable<SelectListItem> GetEnumValueSelectList<TEnum>(this IHtmlHelper htmlHelper) where TEnum : struct
        {
            return new SelectList(Enum.GetValues(typeof(TEnum)).OfType<Enum>()
            .Select(x =>
            new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            }), "Value", "Text");
        }
    }
}

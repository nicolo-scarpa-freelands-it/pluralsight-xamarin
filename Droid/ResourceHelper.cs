using System;
using System.Collections.Generic;
using System.Reflection;

namespace Courses.Droid
{
    public static class ResourceHelper
    {
        static Dictionary<String, int> resourceDictionary = new Dictionary<string, int>();

        public static int TranslateDrawable(String drawableName) 
        {
            int resourceValue = -1;

            switch (drawableName) {
                case "ps_top_card_01":
                    resourceValue = Resource.Drawable.ps_top_card_01;
                    break;
				case "ps_top_card_02":
                    resourceValue = Resource.Drawable.ps_top_card_02;
					break;
				case "ps_top_card_03":
                    resourceValue = Resource.Drawable.ps_top_card_03;
					break;
				case "ps_top_card_04":
                    resourceValue = Resource.Drawable.ps_top_card_04;
					break;
            }

            return resourceValue;
        }

        // Reflection is expensive!
        public static int TranslateDrawableWithReflection(String drawableName) {
            int resourceValue = -1;

			//  Need some caching...
			if (resourceDictionary.ContainsKey(drawableName))
            {
                resourceValue = resourceDictionary[drawableName];
            }
            else
            {
				Type drawableType = typeof(Resource.Drawable);
				FieldInfo resourceFieldInfo = drawableType.GetField(drawableName);

				resourceValue = (int)resourceFieldInfo.GetValue(null);

                resourceDictionary.Add(drawableName, resourceValue);
            }

            return resourceValue;
        }
    }
}

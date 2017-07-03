using System;
using System.Collections.Generic;
using System.Reflection;

namespace Courses.Droid
{
    public static class ResourceHelper
    {
        static Dictionary<String, int> resourceDictionary = new Dictionary<string, int>();

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

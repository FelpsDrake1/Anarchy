﻿using System.Collections.Generic;

namespace Discord
{
    public static class ControllableExtensions
    {
        internal static T SetClient<T>(this T @class, DiscordClient client) where T : Controllable
        {
            if (@class == null) return @class;

            @class.Client = client;
            return @class;
        }


        internal static IReadOnlyList<T> SetClientsInList<T>(this IReadOnlyList<T> classes, DiscordClient client) where T : Controllable
        {
            if (classes == null) return classes;

            foreach (var @class in classes)
                @class.Client = client;

            return classes;
        }
    }
}
using DSharpPlus.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Dultus_Library.Discord
{
    /// <summary>
    /// GuildHelper
    /// </summary>
    public class GuildHelper
    {
        /// <summary>
        /// Beziehen eines <see cref="DiscordGuild"/>-Objekts über dessen Namen.
        /// </summary>
        /// <param name="guild">Die <see cref="DiscordGuild"/> in der gesucht werden soll.</param>
        /// <param name="name">Der gesuchte Name</param>
        /// <param name="CaseRelevant">Ist Groß- und Kleinschreibung relevant?</param>
        /// <returns>Ein <see cref="DiscordGuild"/>-Objekt, welches den gewünschten Namen beinhält.</returns>
        public static DiscordChannel GetChannelByName(ref DiscordGuild guild, string name, bool CaseRelevant = false)
        {
            try
            {
                if (!CaseRelevant)
                    return guild.Channels.Where(x => x.Value.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).First().Value;
                return guild.Channels.Where(x => x.Value.Name.Equals(name)).First().Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Übergibt ein <see cref="List{DiscordGuild}"/>-Objekt mit allen <see cref="DiscordChannel"/>, die den übergebenen Namen im übergebenen <see cref="DiscordChannel"/>-Objekt teilen.
        /// </summary>
        /// <param name="guild">Die <see cref="DiscordGuild"/> in der gesucht werden soll.</param>
        /// <param name="name">Der gesuchte Name</param>
        /// <param name="CaseRelevant">Ist Groß- und Kleinschreibung relevant?</param>
        /// <returns>Ein <see cref="List{DiscordChannel}"/>-Objekt, welches alle Channel mit dem gewünschten Namen beinhält.</returns>
        public static List<DiscordChannel> GetChannelsByName(DiscordGuild guild, string name, bool CaseRelevant = false)
        {
            try
            {
                if (!CaseRelevant)
                    return guild.Channels.Where(x => x.Value.Name.Equals(name, StringComparison.OrdinalIgnoreCase)).Select(x => x.Value).ToList();
                return guild.Channels.Where(x => x.Value.Name.Equals(name)).Select(x => x.Value).ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

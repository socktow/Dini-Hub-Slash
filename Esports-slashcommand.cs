// LOL
    [SlashCommand("lol", "Find Team LEAGUE OF LEGENDS")]
    public async Task FindTeamLOL(
    [
    Choice("Sắt", "IRON"),
    Choice("Đồng", "BRONZE"),
    Choice("Bạc", "SILVER"),
    Choice("Vàng", "GOLD"),
    Choice("Bạch Kim", "PLATIUM"),
    Choice("Lục Bảo","EMERALD"),
    Choice("Kim Cương", "DIAMOND"),
    Choice("Cao Thủ", "MASTER"),
    Choice("Đại Cao Thủ", "GRANDMASTER"),
    Choice("Thách Đấu", "CHALLENGER"),
    Choice("Aram", "ARAM"),
    Choice("Đánh Thường", "NORMAL"),
    Choice("[Chế Độ Giới Hạn] URF", "URF")
    ]
    string LOLMode,
    string Msg = "")
    {
        if (ctx.User is not IVoiceState voiceState || voiceState.VoiceChannel == null)
        {
            await ctx.Interaction.RespondAsync("Need to be in a voice channel to use this command.");
            return;
        }

        var voiceChannel = voiceState.VoiceChannel;
        var users = await voiceChannel.GetUsersAsync().ToListAsync();
        var userCount = users.Count;
        var channelName = voiceChannel.Name;
        var slotValue = userCount == 0 ? "∞" : $"{userCount} / {(voiceChannel.UserLimit.HasValue ? voiceChannel.UserLimit.ToString() : "unlimited")}";
        var invite = await voiceChannel.CreateInviteAsync(maxAge: (int)TimeSpan.FromHours(1).TotalSeconds);
        var inviteUrl = invite.Url;

        var thumbnailUrl = GetThumbnailUrl("lol", LOLMode); // Lấy URL cho thumbnail dựa trên rank mode

        var builder = new ComponentBuilder()
            .WithButton($"Tham gia : {channelName}", style: ButtonStyle.Link, url: inviteUrl, emote: "<:icons_lol:1206391029608091679>".ToIEmote())
            .WithButton("Discord Hỗ Trợ", url: "https://discord.gg/dinogaming", style: ButtonStyle.Link, emote: "<a:thongbso:1200132023302500453>".ToIEmote());
        var eb = new EmbedBuilder()
            .WithAuthor(ctx.User.Username, ctx.User.GetAvatarUrl(), ctx.User.GetAvatarUrl())
            .AddField("> **Room**", $"**> {channelName}**", inline: true)
            .AddField("> **Slots**", $"**> {slotValue}**", inline: true)
            .AddField("> **Rank/Mode**", $"**> {LOLMode}**", inline: true)
            .WithThumbnailUrl(thumbnailUrl) // Đặt URL cho thumbnail
            .WithFooter("/help [lol] [msg]- để tìm đồng đội")
            .WithTimestamp(DateTime.Now)
            .WithOkColor();
        var messageContent = $"**{ctx.User.Mention}{Msg}**";

        await ctx.Interaction.RespondAsync(messageContent, embed: eb.Build(), components: builder.Build()).ConfigureAwait(false);
    }
    // VALORANT 
    [SlashCommand("val", "Find Team VALORANT")]
    public async Task FindTeamVAL(
    [
    Choice("Iron","Iron"),
    Choice("Bronze","Bronze"),
    Choice("Silver","Silver"),
    Choice("Gold ","Gold"),
    Choice("Platinum","Platinum"),
    Choice("Diamond","Diamond"),
    Choice("Ascendant","Ascendant"),
    Choice("Immortal","Immortal"),
    Choice("Radiant","Radiant"),
    Choice("Unrated","Unrated"),
    Choice("Spike Rush","Spike Rush")
    ]
        string VALMode,
        string Msg = "")
    {
        if (ctx.User is not IVoiceState voiceState || voiceState.VoiceChannel == null)
        {
            await ctx.Interaction.RespondAsync("Need to be in a voice channel to use this command.");
            return;
        }

        var voiceChannel = voiceState.VoiceChannel;
        var users = await voiceChannel.GetUsersAsync().ToListAsync();
        var userCount = users.Count;
        var channelName = voiceChannel.Name;
        var slotValue = userCount == 0 ? "∞" : $"{userCount} / {(voiceChannel.UserLimit.HasValue ? voiceChannel.UserLimit.ToString() : "unlimited")}";
        var invite = await voiceChannel.CreateInviteAsync(maxAge: (int)TimeSpan.FromHours(1).TotalSeconds);
        var inviteUrl = invite.Url;
        var thumbnailUrl = GetThumbnailUrl("val", VALMode.ToLower());
        // Lấy URL cho thumbnail dựa trên rank mode
        var builder = new ComponentBuilder()
            .WithButton($"Tham gia : {channelName}", style: ButtonStyle.Link, url: inviteUrl, emote: "<:LVT_Valorant:1206641008339849307>".ToIEmote())
            .WithButton("Discord Hỗ Trợ", url: "https://discord.gg/dinogaming", style: ButtonStyle.Link, emote: "<a:thongbso:1200132023302500453>".ToIEmote());
        var eb = new EmbedBuilder()
            .WithAuthor(ctx.User.Username, ctx.User.GetAvatarUrl(), ctx.User.GetAvatarUrl())
            .AddField("> **Room**", $"**> {channelName}**", inline: true)
            .AddField("> **Slots**", $"**> {slotValue}**", inline: true)
            .AddField("> **Rank/Mode**", $"**> {VALMode}**", inline: true)
            .WithThumbnailUrl(thumbnailUrl) // Đặt URL cho thumbnail
            .WithFooter("/help val - để tìm đồng đội")
            .WithTimestamp(DateTime.Now)
            .WithOkColor();
        var messageContent = $"**{ctx.User.Mention}{Msg}**";
        await ctx.Interaction.RespondAsync(messageContent, embed: eb.Build(), components: builder.Build()).ConfigureAwait(false);
    }
    public string GetThumbnailUrl(string game, string rank)
    {
        Console.WriteLine($"Game: {game}, Rank: {rank}");
        if (game.ToLower() == "lol")
        {
            switch (rank.ToLower())
            {
                case "sắt":
                case "iron":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/iron.png";
                case "đồng":
                case "bronze":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/bronze.png";
                case "bạc":
                case "silver":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/silver.png";
                case "vàng":
                case "gold":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/gold.png";
                case "bạch Kim":
                case "platium":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/platinum.png";
                case "lục bảo":
                case "emerald":
                    return "https://images.contentstack.io/v3/assets/blt731acb42bb3d1659/bltffdd214e7a3cd51e/65496017970384040a35792b/Emblems_emerald.png";
                case "kim cương":
                case "diamond":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/diamond.png";
                case "cao thủ":
                case "master":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/master.png";
                case "đại cao thủ":
                case "grandmaster":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/grandmaster.png";
                case "thách đấu":
                case "challenger":
                    return "https://raw.communitydragon.org/latest/plugins/rcp-fe-lol-static-assets/global/default/images/ranked-mini-crests/challenger.png";
                case "aram":
                    return "https://images-ext-2.discordapp.net/external/hb1GA1JuZeD8LRgVJsKT7uhjmVTPsDGm1Pqqb_5G-u8/https/bettergamer.fra1.cdn.digitaloceanspaces.com/media/uploads/788e655d1bc017b4c2841d21c676b7d2.png?format=webp&quality=lossless&width=671&height=671";
                case "urf":
                    return "https://static.wikia.nocookie.net/leagueoflegends/images/2/2e/The_Thinking_Manatee_profileicon.png/revision/latest/smart/width/250/height/250?cb=20170504215412";
                case "đánh thường":
                case "normal":
                    return "https://cdn.discordapp.com/attachments/855800833279131648/1206632240247873566/190c5f6f7f32104a60a0727ed501aaa1.png?ex=65dcb6d8&is=65ca41d8&hm=944520fa3f2d57ba7551f8b8b3b1e0f58278333d3fcdb647cf7558d220c82ff5&";
                default:
                    return "";
            }
        }
        else if (game.ToLower() == "val")
        {
            switch (rank.ToLower())
        {
            case "iron":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209931605167050814/Iron.png?ex=65e8b79e&is=65d6429e&hm=d65d9baee53227e3f995f7e04437ac30fabd013828abd02667b80043d4b31a54&";
            case "bronze":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209931571814076506/BRONZE.png?ex=65e8b796&is=65d64296&hm=e30c2ae5709eecbeb597029dfa88daf0d0fec9e3d4ad62355d3e74e51c393626&";
            case "silver":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209932137675890818/silver.png?ex=65e8b81d&is=65d6431d&hm=b4c87541ab9d84d83712d9663ed29b254533b4512ed66ca04b306df203e213ca&";
            case "gold":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209932161835204608/golden.png?ex=65e8b822&is=65d64322&hm=942f60d3f9ab2b9afe50305964202d6a52ff3f19e54775d510130c85b027ce99&";
            case "platinum":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209932586885840968/platium.png?ex=65e8b888&is=65d64388&hm=aa0bad496e04a13f64a8740f3f980e38aee7e45f3347df05fda72f71dfdee4d1&";
            case "diamond":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209932744277106758/diamond.png?ex=65e8b8ad&is=65d643ad&hm=c3d67053f639ac51295778d2fbc69e4f7a0b1b49f8943db410c29686f2faf8cf&";
            case "ascendant":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209934842045796433/ascendant.png?ex=65e8baa1&is=65d645a1&hm=c4454c5f24f4c9c88621e9b5ecc088e0fc323cb89a4fa352b658631440ff40c0&";
            case "immortal":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209932842344128523/IMMORTAL.png?ex=65e8b8c5&is=65d643c5&hm=f3ff18ac64440960becbe6326461a2a181759edb3387c7411c6eb960df217263&";
            case "radiant":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209933162076049438/RADIANT.png?ex=65e8b911&is=65d64411&hm=c88648088699aab9f4b16c1a33e444b05ca4c55fe63acbf3ea84fa85f93329eb&";
            case "unrated":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209935049630416896/unrated.png?ex=65e8bad3&is=65d645d3&hm=ccf35d851237ea902fb93d0b06b8d37d7de6874ae14e6bf385842aed9cf5cb94&";
            case "spike rush":
                return "https://cdn.discordapp.com/attachments/1209929161506824314/1209935049630416896/unrated.png?ex=65e8bad3&is=65d645d3&hm=ccf35d851237ea902fb93d0b06b8d37d7de6874ae14e6bf385842aed9cf5cb94&";
            default:
                return "";
        }
        }
        else
        {
            return "Trò chơi không hợp lệ";
        }
    }

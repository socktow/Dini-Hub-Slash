[SlashCommand("lol", "Find Team LEAGUE OF LEGENDS")]
    public async Task FindTeamLOL(
    [Choice("Sắt", "IRON"),
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

        var thumbnailUrl = GetThumbnailUrl(LOLMode); // Lấy URL cho thumbnail dựa trên rank mode

        var builder = new ComponentBuilder()
            .WithButton($"Tham gia : {channelName}", style: ButtonStyle.Link, url: inviteUrl, emote: "<:icons_lol:1206391029608091679>".ToIEmote());
        var eb = new EmbedBuilder()
            .WithAuthor(ctx.User.Username, ctx.User.GetAvatarUrl(), ctx.User.GetAvatarUrl())
            .AddField("> **Room**", $"**> {channelName}**", inline: true)
            .AddField("> **Slots**", $"**> {slotValue}**", inline: true)
            .AddField("> **Rank/Mode**", $"**> {LOLMode}**", inline: true)
            .WithThumbnailUrl(thumbnailUrl) // Đặt URL cho thumbnail
            .WithFooter("/help lol - để tìm đồng đội")
            .WithTimestamp(DateTime.Now)
            .WithOkColor();

        var messageContent = $"**{ctx.User.Mention}{Msg}**";

        await ctx.Interaction.RespondAsync(messageContent, embed: eb.Build(), components: builder.Build()).ConfigureAwait(false);
    }
    private string GetThumbnailUrl(string LOLMode)
    {
        switch (LOLMode.ToLower())
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

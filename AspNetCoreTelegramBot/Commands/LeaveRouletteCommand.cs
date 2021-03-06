﻿using AspNetCoreTelegramBot.Attributes;
using AspNetCoreTelegramBot.Database;
using AspNetCoreTelegramBot.Database.Extensions;
using AspNetCoreTelegramBot.Models;
using AspNetCoreTelegramBot.Models.Extensions;

using System;
using System.ComponentModel;
using System.Threading.Tasks;

using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace AspNetCoreTelegramBot.Commands
{
    /// <summary>
    /// Покинуть рулетку
    /// </summary>
    [CommandChatType(ChatType.Group, ChatType.Supergroup)]
    [Description("Покинуть участие в рулетке")]
    internal class LeaveRouletteCommand : IBotCommand
    {
        protected ITelegramBotClient TelegramBotClient { get; }

        protected ApplicationContext ApplicationContext { get; }

        public LeaveRouletteCommand(ITelegramBotClient telegramBotClient, ApplicationContext applicationContext)
        {
            TelegramBotClient = telegramBotClient;
            ApplicationContext = applicationContext;
        }

        public async Task ExecuteAsync(User sender, Chat chat)
        {
            var userChat = await ApplicationContext.GetUserChatAsync(sender, chat);
            if (!userChat.IsRouletteParticipant)
            {
                await TelegramBotClient.SendTextMessageAsync(chat.TelegramId, $"{sender.GetFullName()}, вы уже покинули рулетку!");
            }
            else
            {
                if (userChat.RouletteJoinDate + TimeSpan.FromDays(1) > DateTime.UtcNow)
                {
                    await TelegramBotClient.SendTextMessageAsync(chat.TelegramId, $"{sender.GetFullName()}, покинуть рулетку можно только через 24 часа после присоединения!");
                }
                else
                {
                    userChat.IsRouletteParticipant = false;
                    await ApplicationContext.SaveChangesAsync();
                    await TelegramBotClient.SendTextMessageAsync(chat.TelegramId, $"{sender.GetFullName()} покинул рулетку :C");
                }
            }
        }
    }
}
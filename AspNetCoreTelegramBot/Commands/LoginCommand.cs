﻿namespace AspNetCoreTelegramBot.Commands
{
    ///// <summary>
    ///// Команда /login
    ///// </summary>
    //[CommandChatType(ChatType.Private)]
    //[Description("Получить логин для входа в панель управления")]
    //internal class LoginCommand : IBotCommand
    //{
    //    private readonly IConfiguration configuration;

    //    protected ITelegramBotClient TelegramBotClient { get; }

    //    protected ApplicationContext ApplicationContext { get; }

    //    public LoginCommand(IConfiguration configuration, ITelegramBotClient telegramBotClient, ApplicationContext applicationContext)
    //    {
    //        this.configuration = configuration;
    //        TelegramBotClient = telegramBotClient;
    //        ApplicationContext = applicationContext;
    //    }

    //    public async Task ExecuteAsync(User sender, Chat chat)
    //    {
    //        if (string.IsNullOrEmpty(sender.Login))
    //        {
    //            sender.Login = sender.Username ?? $"user_{sender.Id}";
    //            await ApplicationContext.SaveChangesAsync();
    //        }

    //        var domain = configuration.GetValue<string>("DOMAIN");
    //        await TelegramBotClient.SendTextMessageAsync(chat.TelegramId, $"Ваш логин для входа: {sender.Login}.\nАдрес для входа в панель: {domain}");
    //    }
    //}
}
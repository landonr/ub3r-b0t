using Discord.WebSocket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UB3RB0T
{
    public partial class Bot
    {
		public void CreateSlackBot()
		{
			var bot = new Slackbot.Bot("xoxb-186062788998-4YRrImSSyDRvvMLUmYQt1DQ2", "robolando");

			bot.OnMessage += (sender, message) =>
			{
				SocketMessage socketMessage;
			}

			bot.OnMessage += (sender, message) =>
			{
				if (message.MentionedUsers.Any(user => user == "robolando"))
				{
					bot.SendMessage(message.Channel, $"Hi {message.User}, thanks for mentioning my name!");
				}
			};
		}
	}
}

﻿using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Dialogs
{
    [Serializable]
    class TaskTodayDialog : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            var taskFormFlow = FormDialog.FromForm(CompletedRemainingTaskForm.TaskForm, FormOptions.PromptInStart);
            context.Call(taskFormFlow, ResumeAfterForm);
        }

        public async Task ResumeAfterForm(IDialogContext context, IAwaitable<CompletedRemainingTaskForm> result)
        {
            var message = await result;

            if (message.taskTypes.ToString().Equals("RemainingTask"))
            {
                await context.PostAsync("Remaining Task for today:: \n" + "1. ICR-1 Develop login page. \n" + "2. ICR-2 Develop home page.");
                context.Done(true);
            }
            else if (message.taskTypes.ToString().Equals("CompletedTask"))
            {
                await context.PostAsync("Completed Task for today:: \n" + "1. ICR-1 Develop login page. \n" + "2. ICR-2 Develop home page.");
                context.Done(true);
            }
        }
    }
}
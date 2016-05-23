using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Orange.Livebox
{
    public static class TaskExtensions
    {
        public static Task OnSuccess(this Task task, Action<Task, object> continueAction, TaskScheduler scheduler = null)
        {
            return task.ContinueWith(continueAction, 
                null,
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion,
                scheduler ?? TaskScheduler.Default);
        }

        public static Task OnFailure(this Task task, Action<Task, object> continueAction, TaskScheduler scheduler = null)
        {
            return task.ContinueWith(continueAction,
                null,
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.NotOnRanToCompletion,
                scheduler ?? TaskScheduler.Default);
        }

        public static Task OnSuccess<T>(this Task<T> task, Action<Task<T>, object> continueAction, TaskScheduler scheduler = null)
        {
            return task.ContinueWith(continueAction,
                null,
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.OnlyOnRanToCompletion,
                scheduler ?? TaskScheduler.Default);
        }

        public static Task OnFailure<T>(this Task<T> task, Action<Task<T>, object> continueAction, TaskScheduler scheduler = null)
        {
            return task.ContinueWith(continueAction,
                null,
                CancellationToken.None,
                TaskContinuationOptions.AttachedToParent | TaskContinuationOptions.NotOnRanToCompletion,
                scheduler ?? TaskScheduler.Default);
        }
    }
}

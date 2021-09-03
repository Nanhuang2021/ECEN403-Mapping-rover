/****************************
 * Code created with the help of YouTube channel: "AngelSix"
 * YouTube Video URL: https://www.youtube.com/watch?v=r2e2bmcfdL0 
 * "AngelSix" Source Code: https://github.com/angelsix/blueberry
 ****************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;

namespace ECEN403_FormsApp.Bluetooth
{
    /// <summary>
    /// Provides helper methods for the <see cref="IAsyncOperation"/>
    /// </summary>
    public static class AsyncOperationExtensions
    {
        /// <summary>
        /// Convert an <see cref="IAsyncOperation{TResult}"/>
        /// into a <see cref="Task{TResult}"/>
        /// </summary>
        /// <typeparam name="TResult">The type of result expected</typeparam>
        /// <param name="operation">The Async Operation</param>
        /// <returns></returns>
        public static Task<TResult> AsTask<TResult>(this IAsyncOperation<TResult> operation)
        {
            // Create task completion result
            // tcs -> task completion sources
            var tcs = new TaskCompletionSource<TResult>();

            // When the operation is completed...
            operation.Completed += delegate
            {
                switch (operation.Status)
                {
                    // If successful...
                    case AsyncStatus.Completed:
                        // Set result
                        tcs.TrySetResult(operation.GetResults());
                        break;
                    // If exception...
                    case AsyncStatus.Error:
                        // Set exception 
                        tcs.TrySetException(operation.ErrorCode);
                        break;
                    // If canceled...
                    case AsyncStatus.Canceled:
                        // Set task as canceled
                        tcs.SetCanceled();
                        break;
                }
            };

            // Return the task
            return tcs.Task;
        }
    }
}

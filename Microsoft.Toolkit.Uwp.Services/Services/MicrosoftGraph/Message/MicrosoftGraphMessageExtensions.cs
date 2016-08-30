﻿// ******************************************************************
//
// Copyright (c) Microsoft. All rights reserved.
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
//
// ******************************************************************

namespace Microsoft.Toolkit.Uwp.Services.MicrosoftGraph
{
    using System.Collections.ObjectModel;
    using System.Threading;
    using System.Threading.Tasks;
    using Graph;
    using System.Collections.Generic;

    /// <summary>
    /// GraphServiceClient Extensions
    /// </summary>
    public static class MicrosoftGraphMessageExtensions
    {
        /// <summary>
        /// IUserMessagesCollectionPage extension collecting the next page of messages
        /// </summary>
        /// <param name="nextPage">Instance of IUserMessagesCollectionPage</param>
        /// <param name="cancellationToken">The <see cref="CancellationToken"/> for the request.</param>
        /// <returns>the next collection of messages or null if there are anymore messages</returns>
        public static Task<IUserMessagesCollectionPage> NextPageAsync(this IUserMessagesCollectionPage nextPage, CancellationToken cancellationToken)
        {
            if (nextPage.NextPageRequest != null)
            {
                return nextPage.NextPageRequest.GetAsync(cancellationToken);
            }

            // no more messages
            return null;
        }

        /// <summary>
        /// IUserMessagesCollectionPage extension collecting the next page of messages
        /// </summary>
        /// <param name="nextPage">Instance of IUserMessagesCollectionPage</param>
        /// <returns>the next collection of messages or null if there are anymore messages</returns>
        public static async Task<IUserMessagesCollectionPage> NextPageAsync(this IUserMessagesCollectionPage nextPage)
        {

            return await nextPage.NextPageAsync(CancellationToken.None);
        }

        /// <summary>
        /// Add items from source to dest
        /// </summary>
        /// <param name="source">A collection of messages</param>
        /// <param name="dest">The destination collection</param>
        public static void AddTo(this IUserMessagesCollectionPage source, ObservableCollection<Graph.Message> dest)
        {
            foreach (var item in source)
            {
                dest.Add(item);
            }
        }

        /// <summary>
        /// Create a list of recipients
        /// </summary>
        /// <param name="source">A collection of email addresses</param>
        /// <param name="dest">A collection of Microsoft Graph recipients</param>
        public static void CopyTo(this string[] source, List<Recipient> dest)
        {
            foreach (var recipient in source)
            {
                dest.Add(new Recipient
                {
                    EmailAddress = new EmailAddress
                    {
                        Address = recipient,
                    }
                });
            }
        }
    }
}

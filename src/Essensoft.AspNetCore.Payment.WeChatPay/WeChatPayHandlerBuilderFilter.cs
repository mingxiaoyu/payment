﻿using System;
using System.Net.Http;
using Essensoft.AspNetCore.Payment.WeChatPay.Utility;
using Microsoft.Extensions.Http;

namespace Essensoft.AspNetCore.Payment.WeChatPay
{
    public class WeChatPayHandlerBuilderFilter : IHttpMessageHandlerBuilderFilter
    {
        private readonly WeChatPayClientCertificateManager _clientCertificateManager;

        public WeChatPayHandlerBuilderFilter(WeChatPayClientCertificateManager clientCertificateManager)
        {
            _clientCertificateManager = clientCertificateManager;
        }

        public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            return (builder) =>
            {
                next(builder);

                if (builder.PrimaryHandler is HttpClientHandler handler)
                {
                    if (builder.Name.Contains(WeChatPayClient.Prefix))
                    {
                        var hash = builder.Name.RemovePreFix(WeChatPayClient.Prefix);
                        if (_clientCertificateManager.TryGetValue(hash, out var clientCertificate))
                        {
                            handler.ClientCertificates.Add(clientCertificate);
                        }
                    }
                }
            };
        }
    }
}

﻿using System.Collections.Generic;
using Essensoft.AspNetCore.Payment.Alipay.Domain;
using Newtonsoft.Json;

namespace Essensoft.AspNetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataDataserviceAdPrincipalQueryResponse.
    /// </summary>
    public class AlipayDataDataserviceAdPrincipalQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 商家支付宝PID
        /// </summary>
        [JsonProperty("alipay_pid")]
        public string AlipayPid { get; set; }

        /// <summary>
        /// 商家的全量资质列表
        /// </summary>
        [JsonProperty("attachment_list")]
        public List<OuterAttachment> AttachmentList { get; set; }

        /// <summary>
        /// 商家id
        /// </summary>
        [JsonProperty("principal_id")]
        public long PrincipalId { get; set; }

        /// <summary>
        /// 状态：  ENABLE-生效  DISABLE-失效  CHECKING-待审核  FAILEDCHECK-审核未通过  INIT-初始化  RE_SIGN-待重签
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        /// <summary>
        /// 二级行业ID
        /// </summary>
        [JsonProperty("trade_id")]
        public string TradeId { get; set; }
    }
}

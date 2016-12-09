﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Management.DataLake.Analytics.Models;
using System.Collections;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet(VerbsCommon.Set, "AzureRmDataLakeAnalyticsAccount"), OutputType(typeof(PSDataLakeAnalyticsAccount))]
    [Alias("Set-AdlAnalyticsAccount")]
    public class SetAzureDataLakeAnalyticsAccount : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "Name of the account.")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = false,
            HelpMessage =
                "A string,string dictionary of tags associated with this account that should replace the current set of tags"
            )]
        [ValidateNotNull]
        public Hashtable Tags { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage = "Name of resource group under which you want to update the account.")]
        [ValidateNotNullOrEmpty]
        public string ResourceGroupName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The maximum supported degree of parallelism for this account.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? MaxDegreeOfParallelism { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The maximum supported jobs running under the account at the same time.")]
        [ValidateNotNull]
        [ValidateRange(1, int.MaxValue)]
        public int? MaxJobCount { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Mandatory = false,
            HelpMessage = "The number of days that job metadata is retained.")]
        [ValidateNotNull]
        [ValidateRange(1, 180)]
        public int? QueryStoreRetention { get; set; }

        public override void ExecuteCmdlet()
        {
            WriteObject(new PSDataLakeAnalyticsAccount(DataLakeAnalyticsClient.CreateOrUpdateAccount(ResourceGroupName, Name, null, null,
                    null, null, Tags, MaxDegreeOfParallelism, MaxJobCount, QueryStoreRetention)));
        }
    }
}
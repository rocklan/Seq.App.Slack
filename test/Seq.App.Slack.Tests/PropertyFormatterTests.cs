﻿using System.Collections.Generic;
using Xunit;

namespace Seq.App.Slack.Tests
{
    public class PropertyFormatterTests
    {
        SlackReactor slackReactor = new SlackReactor();

        [Fact]
        public void IntPropertyFormattedOk()
        {
            var result = slackReactor.convertPropertyValueToString(1);
            Assert.Equal("1", result);
        }

        [Fact]
        public void NullPropertyFormattedOk()
        {
            var result = slackReactor.convertPropertyValueToString(null);
            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void DictionaryPropertiesSerialisedAsJson()
        {
            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("test", "value");
            d.Add("test2", "value2");
            var result = slackReactor.convertPropertyValueToString(d);
            var expected = "{\"test\":\"value\",\"test2\":\"value2\"}";
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DictionaryPropertiesSerialisedAsJsonShouldTruncate()
        {
            slackReactor.JsonTrunateAt = 5;

            Dictionary<string, string> d = new Dictionary<string, string>();
            d.Add("test", "value");
            var result = slackReactor.convertPropertyValueToString(d);
            var expected = "{\"tes...";
            Assert.Equal(expected, result);
        }

    }

}

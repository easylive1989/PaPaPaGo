﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PapapaGo.Sample
{
    public abstract class RequestBase
    {
        public Dictionary<string, string> GetSignatureSources()
        {
            var dic = new Dictionary<string, string>();
            var properties = this.GetType().GetProperties();
            foreach (var prop in properties)
            {
                var attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    var authAttr = attr as JsonPropertyAttribute;
                    if (authAttr != null)
                    {
                        if (authAttr.PropertyName == "seat_reserved")
                        {
                            dic[authAttr.PropertyName] = prop.GetValue(this).ToString().ToLower();
                        }
                        else
                        {
                            dic[authAttr.PropertyName] = prop.GetValue(this).ToString();
                        }
                    }
                }
            }

            return dic;
        }

        public string GetURL()
        {
            var dic = GetSignatureSources();
            return string.Join("&", dic.Select(x => $"{x.Key}={x.Value}"));
        }
    }
}
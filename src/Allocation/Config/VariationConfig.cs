﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace Allocation.Config
{
    public class VariationConfig
    {
        [JsonPropertyName("id")]
        public int ID { get; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("weight")]
        public uint Weight { get; set; }

        public VariationConfig(int id, string name, uint weight)
        {
            ID = id;
            Name = name;
            Weight = weight;
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}

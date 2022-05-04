﻿using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SymplifySDK.Allocation.Exceptions;

namespace SymplifySDK.Allocation.Config
{
    public class SymplifyConfig
    {
        [JsonPropertyName("updated")]
        public int Updated { get; set; }

        [JsonPropertyName("projects")]
        public List<ProjectConfig> Projects { get; set; }

        public SymplifyConfig() { }
        public SymplifyConfig(int updated, List<ProjectConfig> projects)
        {
            Updated = updated;
            Projects = projects;
        }

        public SymplifyConfig(string json)
        {
            try
            {
                char[] charsToTrim = { '\xEF', ' ', '\xBF', '\xBB' };
                SymplifyConfig config = JsonSerializer.Deserialize<SymplifyConfig>(json.Trim(charsToTrim));

                Updated = config.Updated;
                Projects = config.Projects;
            }
            catch (Exception)
            {
                throw new Exception("Invalid json");
            }
        }


        public ProjectConfig FindProjectWithName(string projectName)
        {
            foreach (ProjectConfig project in this.Projects)
            {
                if (project.Name == projectName)
                {
                    return project;
                }
            }

            // TODO Add better message
            throw new ProjectException.NotFoundException("Project not found");
        }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
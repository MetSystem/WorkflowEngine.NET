﻿using System;
using MySql.Data.MySqlClient;

namespace OptimaJet.Workflow.MySQL
{
    public class WorkflowProcessInstance: DbObject<WorkflowProcessInstance>
    {
        public string ActivityName { get; set; }
        public Guid Id { get; set; }
        public bool IsDeterminingParametersChanged { get; set; }
        public string PreviousActivity { get; set; }
        public string PreviousActivityForDirect { get; set; }
        public string PreviousActivityForReverse { get; set; }
        public string PreviousState { get; set; }
        public string PreviousStateForDirect { get; set; }
        public string PreviousStateForReverse { get; set; }
        public Guid? SchemeId { get; set; }
        public string StateName { get; set; }
        public Guid? ParentProcessId { get; set; }
        public Guid RootProcessId { get; set; }
        public WorkflowProcessInstance(): base()
        {
            db_TableName = "WorkflowProcessInstance";
            db_Columns.AddRange(new ColumnInfo[]
            {
                new ColumnInfo() {Name = "Id", IsKey = true, Type = MySqlDbType.Binary},
                new ColumnInfo() {Name = "ActivityName"},
                new ColumnInfo() {Name = "IsDeterminingParametersChanged", Type = MySqlDbType.Bit},
                new ColumnInfo() {Name = "PreviousActivity"},
                new ColumnInfo() {Name = "PreviousActivityForDirect"},
                new ColumnInfo() {Name = "PreviousActivityForReverse"},
                new ColumnInfo() {Name = "PreviousState"},
                new ColumnInfo() {Name = "PreviousStateForDirect"},
                new ColumnInfo() {Name = "PreviousStateForReverse"},
                new ColumnInfo() {Name = "SchemeId", Type = MySqlDbType.Binary},
                new ColumnInfo() {Name = "StateName"},
                new ColumnInfo() {Name = "ParentProcessId", Type = MySqlDbType.Binary},
                new ColumnInfo() {Name = "RootProcessId", Type = MySqlDbType.Binary},
            });
        }

        public override object GetValue(string key)
        {
            switch (key)
            {
                case "Id":
                    return Id.ToByteArray();
                case "ActivityName":
                    return ActivityName;
                case "IsDeterminingParametersChanged":
                    return IsDeterminingParametersChanged;
                case "PreviousActivity":
                    return PreviousActivity;
                case "PreviousActivityForDirect":
                    return PreviousActivityForDirect;
                case "PreviousActivityForReverse":
                    return PreviousActivityForReverse;
                case "PreviousState":
                    return PreviousState;
                case "PreviousStateForDirect":
                    return PreviousStateForDirect;
                case "PreviousStateForReverse":
                    return PreviousStateForReverse;
                case "SchemeId":
                    return SchemeId.HasValue ? SchemeId.Value.ToByteArray() : null;
                case "StateName":
                    return StateName;
                case "ParentProcessId":
                    return ParentProcessId.HasValue ? ParentProcessId.Value.ToByteArray() : null;
                case "RootProcessId":
                    return RootProcessId.ToByteArray();
                default:
                    throw new Exception(string.Format("Column {0} is not exists", key));
            }
        }

        public override void SetValue(string key, object value)
        {
            switch (key)
            {
                case "Id":
                    Id = new Guid((byte[])value);
                    break;
                case "ActivityName":
                    ActivityName = value as string;
                    break;
                case "IsDeterminingParametersChanged":
                    IsDeterminingParametersChanged = value.ToString() == "1";
                    break;
                case "PreviousActivity":
                    PreviousActivity = value as string;
                    break;
                case "PreviousActivityForDirect":
                    PreviousActivityForDirect = value as string;
                    break;
                case "PreviousActivityForReverse":
                    PreviousActivityForReverse = value as string;
                    break;
                case "PreviousState":
                    PreviousState = value as string;
                    break;
                case "PreviousStateForDirect":
                    PreviousStateForDirect = value as string;
                    break;
                case "PreviousStateForReverse":
                    PreviousStateForReverse = value as string;
                    break;
                case "SchemeId":
                    var bytes = value as byte[];
                    if (bytes != null)
                        SchemeId = new Guid(bytes);
                    else
                        SchemeId = null;
                    break;
                case "StateName":
                    StateName = value as string;
                    break;
                case "ParentProcessId":
                    var bytes1 = value as byte[];
                    if (bytes1 != null)
                        ParentProcessId = new Guid(bytes1);
                    else
                        ParentProcessId = null;
                    break;
                case "RootProcessId":
                    RootProcessId = new Guid((byte[])value);
                    break;
                default:
                    throw new Exception(string.Format("Column {0} is not exists", key));
            }
        }
    }
}

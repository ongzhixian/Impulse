# Logging

## Current logging convention

Start of an operation

`"{operation} {itemType} {itemName} {operationState}"`
`"{operation} table {tableName} {operationState}"`

End of an operation

`"{operation} {itemType} {itemName} {operationState} {result}"`
`"{operation} table {tableName} {operationState} {result}"`

logger.LogInformation("{operation} table {tableName} {operationState} {result}", Operation.CheckIfExist, tableName, OperationState.End, result.AsExists());

logger.LogError(e, "{functionName} {dataType} {dataValue}", nameof(MapAttributeValue), dataType, dataValue);

ERROR|Client  |MapAttributeValue N 1001 Unable to cast object of type 'System.Int32' to type 'System.String'.|functionName=MapAttributeValue, dataType=N, dataValue=1001
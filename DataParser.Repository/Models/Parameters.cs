namespace DataParser
{
    public enum MessageTypes
    {
        ValidationErrorOfIndividualRowParsing,
        ErrorOfApplicationLevel,
        NotificationOfAllParsingCompleted
    }

    public enum InputType
    { Claim,
      Tin}
    public enum SequenceNumber
    {
        claimant1_relation,
        claimant2_relation,
        claimant3_relation,
        claimant4_relation,
        tpoc1_date,
        tpoc2_date,
        tpoc3_date,
        tpoc4_date
    }

    public enum ErrorCode 
    {
        None,
        RREErr,//RRE Id supplied in Claim input file is not yet registered in the system. 
        TINErr,//Combination of TIN and Office Code supplied in Claim input file is not yet registered in the system. 
    }
}

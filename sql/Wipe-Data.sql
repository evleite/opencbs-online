BEGIN TRANSACTION
ALTER TABLE [dbo].[OverdueEvents] DROP CONSTRAINT [FK_OverdueEvents_ContractEvents]
ALTER TABLE [dbo].[FollowUp] DROP CONSTRAINT [FK_FollowUp_Projects]
ALTER TABLE [dbo].[SavingDepositContracts] DROP CONSTRAINT [FK_SavingDepositContract_SavingContracts]
ALTER TABLE [dbo].[VillagesPersons] DROP CONSTRAINT [FK_VillagesPersons_Villages]
ALTER TABLE [dbo].[AllowedRoleMenus] DROP CONSTRAINT [FK_AllowedRoleMenus_Roles]
ALTER TABLE [dbo].[TermDepositProducts] DROP CONSTRAINT [FK_TermDepositProducts_InstallmentTypes]
ALTER TABLE [dbo].[TermDepositProducts] DROP CONSTRAINT [FK_TermDepositProducts_SavingProducts]
ALTER TABLE [dbo].[EventAttributes] DROP CONSTRAINT [FK_EventAttributes_EventTypes]
ALTER TABLE [dbo].[SavingBookContracts] DROP CONSTRAINT [FK_SavingBookContract_SavingContracts]
ALTER TABLE [dbo].[WriteOffEvents] DROP CONSTRAINT [FK_WriteOffEvents_ContractEvents]
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules]
ALTER TABLE [dbo].[FundingLineAccountingRules] DROP CONSTRAINT [FK_FundingLineAccountingRules_FundingLine]
ALTER TABLE [dbo].[VillagesAttendance] DROP CONSTRAINT [FK_VillagesAttendance_Villages]
ALTER TABLE [dbo].[ReschedulingOfALoanEvents] DROP CONSTRAINT [FK_ReschedulingOfALoanEvents_ContractEvents]
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts]
ALTER TABLE [dbo].[ManualAccountingMovements] DROP CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1]
ALTER TABLE [dbo].[ProvisionEvents] DROP CONSTRAINT [FK_ProvisionEvents_ContractEvents]
ALTER TABLE [dbo].[CollateralPropertyValues] DROP CONSTRAINT [FK_CollateralPropertyValues_CollateralProperties]
ALTER TABLE [dbo].[CollateralPropertyValues] DROP CONSTRAINT [FK_CollateralPropertyValues_CollateralsLinkContracts]
ALTER TABLE [dbo].[Villages] DROP CONSTRAINT [FK_Villages_Users]
ALTER TABLE [dbo].[Installments] DROP CONSTRAINT [FK_Installments_Credit]
ALTER TABLE [dbo].[CollateralsLinkContracts] DROP CONSTRAINT [FK_CollateralsLinkContracts_Contracts]
ALTER TABLE [dbo].[Groups] DROP CONSTRAINT [FK_Groups_Tiers]
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts]
ALTER TABLE [dbo].[LoanAccountingMovements] DROP CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1]
ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_EconomicActivities]
ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_Projects]
ALTER TABLE [dbo].[Contracts] DROP CONSTRAINT [FK_Contracts_Villages]
ALTER TABLE [dbo].[CollateralProperties] DROP CONSTRAINT [FK_CollateralProperties_CollateralProducts]
ALTER TABLE [dbo].[CollateralProperties] DROP CONSTRAINT [FK_CollateralProperties_CollateralPropertyTypes]
ALTER TABLE [dbo].[ExoticInstallments] DROP CONSTRAINT [FK_ExoticInstallments_Exotics]
ALTER TABLE [dbo].[CreditEntryFees] DROP CONSTRAINT [FK_CreditEntryFees_Credit]
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Contracts]
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_InstallmentTypes]
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Packages]
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Temp_FundingLines]
ALTER TABLE [dbo].[Credit] DROP CONSTRAINT [FK_Credit_Users]
ALTER TABLE [dbo].[PersonGroupBelonging] DROP CONSTRAINT [FK_PersonGroupBelonging_Persons1]
ALTER TABLE [dbo].[PersonGroupBelonging] DROP CONSTRAINT [FK_PersonGroupCorrespondance_Groups]
ALTER TABLE [dbo].[CorporatePersonBelonging] DROP CONSTRAINT [FK_CorporatePersonBelonging_Corporates]
ALTER TABLE [dbo].[CorporatePersonBelonging] DROP CONSTRAINT [FK_CorporatePersonBelonging_Persons]
ALTER TABLE [dbo].[AdvancedFieldsValues] DROP CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFields]
ALTER TABLE [dbo].[AdvancedFieldsValues] DROP CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities]
ALTER TABLE [dbo].[AdvancedFields] DROP CONSTRAINT [FK_AdvancedFields_AdvancedFieldsEntities]
ALTER TABLE [dbo].[AdvancedFields] DROP CONSTRAINT [FK_AdvancedFields_AdvancedFieldsTypes]
ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_ActionItems]
ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_AllowedRoleActions]
ALTER TABLE [dbo].[AllowedRoleActions] DROP CONSTRAINT [FK_AllowedRoleActions_Roles]
ALTER TABLE [dbo].[TrancheEvents] DROP CONSTRAINT [FK_TrancheEvents_ContractEvents]
ALTER TABLE [dbo].[TellerEvents] DROP CONSTRAINT [FK_TellerEvents_Tellers]
ALTER TABLE [dbo].[LoansLinkSavingsBook] DROP CONSTRAINT [FK_LoansLinkSavingsBook_Contracts]
ALTER TABLE [dbo].[LoansLinkSavingsBook] DROP CONSTRAINT [FK_LoansLinkSavingsBook_SavingContracts]
ALTER TABLE [dbo].[EntryFees] DROP CONSTRAINT [FK_EntryFees_Packages]
ALTER TABLE [dbo].[SavingBookProducts] DROP CONSTRAINT [FK_SavingBookProducts_SavingProducts]
ALTER TABLE [dbo].[SavingProducts] DROP CONSTRAINT [FK_SavingProducts_Currencies]
ALTER TABLE [dbo].[City] DROP CONSTRAINT [FK_City_Districts]
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts]
ALTER TABLE [dbo].[StandardBookings] DROP CONSTRAINT [FK_StandardBookings_ChartOfAccounts1]
ALTER TABLE [dbo].[AmountCycles] DROP CONSTRAINT [FK_AmountCycles_Cycles]
ALTER TABLE [dbo].[Districts] DROP CONSTRAINT [FK_Districts_Provinces]
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts]
ALTER TABLE [dbo].[SavingsAccountingMovements] DROP CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1]
ALTER TABLE [dbo].[ChartOfAccounts] DROP CONSTRAINT [FK_ChartOfAccounts_AccountsCategory]
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_AccountingRules]
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications]
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_Packages]
ALTER TABLE [dbo].[ContractAccountingRules] DROP CONSTRAINT [FK_ContractAccountingRules_SavingProducts]
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts]
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_ChartOfAccounts1]
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventAttributes]
ALTER TABLE [dbo].[AccountingRules] DROP CONSTRAINT [FK_AccountingRules_EventTypes]
ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_SavingContracts]
ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_Tellers]
ALTER TABLE [dbo].[SavingEvents] DROP CONSTRAINT [FK_SavingEvents_Users]
ALTER TABLE [dbo].[Corporates] DROP CONSTRAINT [FK_Corporates_DomainOfApplications]
ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_Currencies]
ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_Cycles]
ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_Exotics]
ALTER TABLE [dbo].[Packages] DROP CONSTRAINT [FK_Packages_InstallmentTypes]
ALTER TABLE [dbo].[Projects] DROP CONSTRAINT [FK_Projects_Tiers]
ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_SavingContracts_Tiers]
ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_SavingContracts_Users]
ALTER TABLE [dbo].[SavingContracts] DROP CONSTRAINT [FK_Savings_SavingProducts]
ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_Banks]
ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_Banks1]
ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_DomainOfApplications]
ALTER TABLE [dbo].[Persons] DROP CONSTRAINT [FK_Persons_Tiers]
ALTER TABLE [dbo].[EconomicActivities] DROP CONSTRAINT [FK_DomainOfApplications_DomainOfApplications]
ALTER TABLE [dbo].[FundingLineEvents] DROP CONSTRAINT [FK_FundingLineEvents_FundingLines]
ALTER TABLE [dbo].[FundingLines] DROP CONSTRAINT [FK_FundingLines_Currencies]
ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Contracts]
ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_LoanInterestAccruingEvents]
ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Tellers]
ALTER TABLE [dbo].[ContractEvents] DROP CONSTRAINT [FK_ContractEvents_Users]
ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_Branches]
ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_ChartOfAccounts]
ALTER TABLE [dbo].[Tellers] DROP CONSTRAINT [FK_Tellers_Currencies]
ALTER TABLE [dbo].[Tiers] DROP CONSTRAINT [FK_Tiers_Branches]
ALTER TABLE [dbo].[Tiers] DROP CONSTRAINT [FK_Tiers_Corporates]
ALTER TABLE [dbo].[Tiers] DROP CONSTRAINT [FK_Tiers_Districts]
ALTER TABLE [dbo].[Tiers] DROP CONSTRAINT [FK_Tiers_Districts1]

DELETE FROM [dbo].[AccountingClosure]
DELETE FROM [dbo].[AccountingRules]
DELETE FROM [dbo].[AccountsCategory]
DELETE FROM [dbo].[AccrualInterestLoanEvents]
DELETE FROM [dbo].[ActionItems]
DELETE FROM [dbo].[AdvancedFieldsCollections]
DELETE FROM [dbo].[AdvancedFieldsEntities]
DELETE FROM [dbo].[AdvancedFieldsLinkEntities]
DELETE FROM [dbo].[AdvancedFieldsTypes]
DELETE FROM [dbo].[AdvancedFieldsValues]
DELETE FROM [dbo].[AdvancedFields]
DELETE FROM [dbo].[AlertSettings]
DELETE FROM [dbo].[AllowedRoleActions]
DELETE FROM [dbo].[AllowedRoleMenus]
DELETE FROM [dbo].[AmountCycles]
DELETE FROM [dbo].[Banks]
DELETE FROM [dbo].[Branches]
DELETE FROM [dbo].[ChartOfAccounts]
DELETE FROM [dbo].[City]
DELETE FROM [dbo].[ClientBranchHistory]
DELETE FROM [dbo].[ClientTypes]
DELETE FROM [dbo].[CollateralProducts]
DELETE FROM [dbo].[CollateralProperties]
DELETE FROM [dbo].[CollateralPropertyCollections]
DELETE FROM [dbo].[CollateralPropertyTypes]
DELETE FROM [dbo].[CollateralPropertyValues]
DELETE FROM [dbo].[CollateralsLinkContracts]
DELETE FROM [dbo].[ConsolidatedData]
DELETE FROM [dbo].[ContractAccountingRules]
DELETE FROM [dbo].[ContractAssignHistory]
DELETE FROM [dbo].[ContractEvents]
DELETE FROM [dbo].[Contracts]
DELETE FROM [dbo].[CorporateEventsType]
DELETE FROM [dbo].[CorporatePersonBelonging]
DELETE FROM [dbo].[Corporates]
DELETE FROM [dbo].[Credit]
DELETE FROM [dbo].[Credit]
DELETE FROM [dbo].[CreditEntryFees]
DELETE FROM [dbo].[CreditInsuranceEvents]
DELETE FROM [dbo].[Currencies]
DELETE FROM [dbo].[CycleObjects]
DELETE FROM [dbo].[CycleParameters]
DELETE FROM [dbo].[Cycles]
DELETE FROM [dbo].[Districts]
DELETE FROM [dbo].[EconomicActivities]
DELETE FROM [dbo].[EconomicActivityLoanHistory]
DELETE FROM [dbo].[EntryFees]
DELETE FROM [dbo].[EventAttributes]
DELETE FROM [dbo].[EventTypes]
DELETE FROM [dbo].[ExchangeRates]
DELETE FROM [dbo].[ExoticInstallments]
DELETE FROM [dbo].[Exotics]
DELETE FROM [dbo].[FiscalYear]
DELETE FROM [dbo].[FollowUp]
DELETE FROM [dbo].[FundingLineAccountingRules]
DELETE FROM [dbo].[FundingLineEvents]
DELETE FROM [dbo].[FundingLines]
DELETE FROM [dbo].[GeneralParameters]
DELETE FROM [dbo].[Groups]
DELETE FROM [dbo].[HousingSituation]
DELETE FROM [dbo].[Info]
DELETE FROM [dbo].[InstallmentHistory]
DELETE FROM [dbo].[Installments]
DELETE FROM [dbo].[InstallmentTypes]
DELETE FROM [dbo].[LateDaysRange]
DELETE FROM [dbo].[LinkBranchesPaymentMethods]
DELETE FROM [dbo].[LinkGuarantorCredit]
DELETE FROM [dbo].[LoanAccountingMovements]
DELETE FROM [dbo].[LoanDisbursmentEvents]
DELETE FROM [dbo].[LoanEntryFeeEvents]
DELETE FROM [dbo].[LoanInterestAccruingEvents]
DELETE FROM [dbo].[LoanPenaltyAccrualEvents]
DELETE FROM [dbo].[LoanScale]
DELETE FROM [dbo].[LoanShareAmounts]
DELETE FROM [dbo].[LoansLinkSavingsBook]
DELETE FROM [dbo].[LoanTransitionEvents]
DELETE FROM [dbo].[ManualAccountingMovements]
DELETE FROM [dbo].[MenuItems]
DELETE FROM [dbo].[MFI]
DELETE FROM [dbo].[Monitoring]
DELETE FROM [dbo].[OverdueEvents]
DELETE FROM [dbo].[Packages]
DELETE FROM [dbo].[PackagesClientTypes]
DELETE FROM [dbo].[PaymentMethods]
DELETE FROM [dbo].[PersonGroupBelonging]
DELETE FROM [dbo].[Persons]
DELETE FROM [dbo].[PersonsPhotos]
DELETE FROM [dbo].[ProjectPurposes]
DELETE FROM [dbo].[Projects]
DELETE FROM [dbo].[Provinces]
DELETE FROM [dbo].[ProvisionEvents]
DELETE FROM [dbo].[ProvisioningRules]
DELETE FROM [dbo].[PublicHolidays]
DELETE FROM [dbo].[Questionnaire]
DELETE FROM [dbo].[Rep_Active_Loans_Data]
DELETE FROM [dbo].[Rep_Disbursements_Data]
DELETE FROM [dbo].[Rep_OLB_and_LLP_Data]
DELETE FROM [dbo].[Rep_Par_Analysis_Data]
DELETE FROM [dbo].[Rep_Repayments_Data]
DELETE FROM [dbo].[Rep_Rescheduled_Loans_Data]
DELETE FROM [dbo].[RepaymentEvents]
DELETE FROM [dbo].[ReschedulingOfALoanEvents]
DELETE FROM [dbo].[SavingBookContracts]
DELETE FROM [dbo].[SavingBookProducts]
DELETE FROM [dbo].[SavingContracts]
DELETE FROM [dbo].[SavingDepositContracts]
DELETE FROM [dbo].[SavingEvents]
DELETE FROM [dbo].[SavingProducts]
DELETE FROM [dbo].[SavingProductsClientTypes]
DELETE FROM [dbo].[SavingsAccountingMovements]
DELETE FROM [dbo].[SetUp_ActivityState]
DELETE FROM [dbo].[SetUp_BankSituation]
DELETE FROM [dbo].[SetUp_BusinessPlan]
DELETE FROM [dbo].[SetUp_DwellingPlace]
DELETE FROM [dbo].[SetUp_FamilySituation]
DELETE FROM [dbo].[SetUp_FiscalStatus]
DELETE FROM [dbo].[SetUp_HousingLocation]
DELETE FROM [dbo].[SetUp_HousingSituation]
DELETE FROM [dbo].[SetUp_InsertionTypes]
DELETE FROM [dbo].[SetUp_LegalStatus]
DELETE FROM [dbo].[SetUp_PersonalSituation]
DELETE FROM [dbo].[SetUp_ProfessionalExperience]
DELETE FROM [dbo].[SetUp_ProfessionalSituation]
DELETE FROM [dbo].[SetUp_Registre]
DELETE FROM [dbo].[SetUp_SageJournal]
DELETE FROM [dbo].[SetUp_SocialSituation]
DELETE FROM [dbo].[SetUp_Sponsor1]
DELETE FROM [dbo].[SetUp_Sponsor2]
DELETE FROM [dbo].[SetUp_StudyLevel]
DELETE FROM [dbo].[SetUp_SubventionTypes]
DELETE FROM [dbo].[StandardBookings]
DELETE FROM [dbo].[Statuses]
DELETE FROM [dbo].[TechnicalParameters]
DELETE FROM [dbo].[TellerEvents]
DELETE FROM [dbo].[Tellers]
DELETE FROM [dbo].[TermDepositProducts]
DELETE FROM [dbo].[Test]
DELETE FROM [dbo].[Tiers]
DELETE FROM [dbo].[TraceUserLogs]
DELETE FROM [dbo].[TrancheEvents]
DELETE FROM [dbo].[UsersBranches]
DELETE FROM [dbo].[UserRole]
DELETE FROM [dbo].[UsersSubordinates]
DELETE FROM [dbo].[Users]
DELETE FROM [dbo].[Roles]
DELETE FROM [dbo].[Villages]
DELETE FROM [dbo].[VillagesAttendance]
DELETE FROM [dbo].[VillagesPersons]
DELETE FROM [dbo].[WriteOffEvents]
DELETE FROM [dbo].[WriteOffOptions]

DELETE FROM [dbo].[TokenStorage]

ALTER TABLE [dbo].[OverdueEvents]
    ADD CONSTRAINT [FK_OverdueEvents_ContractEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[ContractEvents] ([id])
ALTER TABLE [dbo].[FollowUp]
    ADD CONSTRAINT [FK_FollowUp_Projects] FOREIGN KEY ([project_id]) REFERENCES [dbo].[Projects] ([id])
ALTER TABLE [dbo].[SavingDepositContracts]
    ADD CONSTRAINT [FK_SavingDepositContract_SavingContracts] FOREIGN KEY ([id]) REFERENCES [dbo].[SavingContracts] ([id])
ALTER TABLE [dbo].[VillagesPersons]
    ADD CONSTRAINT [FK_VillagesPersons_Villages] FOREIGN KEY ([village_id]) REFERENCES [dbo].[Villages] ([id])
ALTER TABLE [dbo].[AllowedRoleMenus]
    ADD CONSTRAINT [FK_AllowedRoleMenus_Roles] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Roles] ([id])
ALTER TABLE [dbo].[TermDepositProducts]
    ADD CONSTRAINT [FK_TermDepositProducts_InstallmentTypes] FOREIGN KEY ([installment_types_id]) REFERENCES [dbo].[InstallmentTypes] ([id])
ALTER TABLE [dbo].[TermDepositProducts]
    ADD CONSTRAINT [FK_TermDepositProducts_SavingProducts] FOREIGN KEY ([id]) REFERENCES [dbo].[SavingProducts] ([id])
ALTER TABLE [dbo].[EventAttributes]
    WITH NOCHECK ADD CONSTRAINT [FK_EventAttributes_EventTypes] FOREIGN KEY ([event_type]) REFERENCES [dbo].[EventTypes] ([event_type]) NOT FOR REPLICATION
ALTER TABLE [dbo].[SavingBookContracts]
    ADD CONSTRAINT [FK_SavingBookContract_SavingContracts] FOREIGN KEY ([id]) REFERENCES [dbo].[SavingContracts] ([id])
ALTER TABLE [dbo].[WriteOffEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_WriteOffEvents_ContractEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[ContractEvents] ([id]);


GO
ALTER TABLE [dbo].[WriteOffEvents] NOCHECK CONSTRAINT [FK_WriteOffEvents_ContractEvents]
ALTER TABLE [dbo].[FundingLineAccountingRules]
    ADD CONSTRAINT [FK_FundingLineAccountingRules_AccountingRules] FOREIGN KEY ([id]) REFERENCES [dbo].[AccountingRules] ([id])
ALTER TABLE [dbo].[FundingLineAccountingRules]
    ADD CONSTRAINT [FK_FundingLineAccountingRules_FundingLine] FOREIGN KEY ([funding_line_id]) REFERENCES [dbo].[FundingLines] ([id])
ALTER TABLE [dbo].[VillagesAttendance]
    ADD CONSTRAINT [FK_VillagesAttendance_Villages] FOREIGN KEY ([village_id]) REFERENCES [dbo].[Villages] ([id])
ALTER TABLE [dbo].[ReschedulingOfALoanEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_ReschedulingOfALoanEvents_ContractEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[ContractEvents] ([id]);


GO
ALTER TABLE [dbo].[ReschedulingOfALoanEvents] NOCHECK CONSTRAINT [FK_ReschedulingOfALoanEvents_ContractEvents]
ALTER TABLE [dbo].[ManualAccountingMovements]
    ADD CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts] FOREIGN KEY ([debit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[ManualAccountingMovements]
    ADD CONSTRAINT [FK_ManualAccountingMovements_ChartOfAccounts1] FOREIGN KEY ([credit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[ProvisionEvents]
    ADD CONSTRAINT [FK_ProvisionEvents_ContractEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[ContractEvents] ([id])
ALTER TABLE [dbo].[CollateralPropertyValues]
    ADD CONSTRAINT [FK_CollateralPropertyValues_CollateralProperties] FOREIGN KEY ([property_id]) REFERENCES [dbo].[CollateralProperties] ([id])
ALTER TABLE [dbo].[CollateralPropertyValues]
    ADD CONSTRAINT [FK_CollateralPropertyValues_CollateralsLinkContracts] FOREIGN KEY ([contract_collateral_id]) REFERENCES [dbo].[CollateralsLinkContracts] ([id])
ALTER TABLE [dbo].[Villages]
    ADD CONSTRAINT [FK_Villages_Users] FOREIGN KEY ([loan_officer]) REFERENCES [dbo].[Users] ([id])
ALTER TABLE [dbo].[Installments]
    WITH NOCHECK ADD CONSTRAINT [FK_Installments_Credit] FOREIGN KEY ([contract_id]) REFERENCES [dbo].[Credit] ([id]);


GO
ALTER TABLE [dbo].[Installments] NOCHECK CONSTRAINT [FK_Installments_Credit]
ALTER TABLE [dbo].[CollateralsLinkContracts]
    ADD CONSTRAINT [FK_CollateralsLinkContracts_Contracts] FOREIGN KEY ([contract_id]) REFERENCES [dbo].[Contracts] ([id])
ALTER TABLE [dbo].[Groups]
    WITH NOCHECK ADD CONSTRAINT [FK_Groups_Tiers] FOREIGN KEY ([id]) REFERENCES [dbo].[Tiers] ([id]);


GO
ALTER TABLE [dbo].[Groups] NOCHECK CONSTRAINT [FK_Groups_Tiers]
ALTER TABLE [dbo].[LoanAccountingMovements]
    ADD CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts] FOREIGN KEY ([debit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[LoanAccountingMovements]
    ADD CONSTRAINT [FK_LoanAccountingMovements_ChartOfAccounts1] FOREIGN KEY ([credit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[Contracts]
    ADD CONSTRAINT [FK_Contracts_EconomicActivities] FOREIGN KEY ([activity_id]) REFERENCES [dbo].[EconomicActivities] ([id])
ALTER TABLE [dbo].[Contracts]
    ADD CONSTRAINT [FK_Contracts_Projects] FOREIGN KEY ([project_id]) REFERENCES [dbo].[Projects] ([id])
ALTER TABLE [dbo].[Contracts]
    ADD CONSTRAINT [FK_Contracts_Villages] FOREIGN KEY ([nsg_id]) REFERENCES [dbo].[Villages] ([id])
ALTER TABLE [dbo].[CollateralProperties]
    ADD CONSTRAINT [FK_CollateralProperties_CollateralProducts] FOREIGN KEY ([product_id]) REFERENCES [dbo].[CollateralProducts] ([id])
ALTER TABLE [dbo].[CollateralProperties]
    ADD CONSTRAINT [FK_CollateralProperties_CollateralPropertyTypes] FOREIGN KEY ([type_id]) REFERENCES [dbo].[CollateralPropertyTypes] ([id])
ALTER TABLE [dbo].[ExoticInstallments]
    WITH NOCHECK ADD CONSTRAINT [FK_ExoticInstallments_Exotics] FOREIGN KEY ([exotic_id]) REFERENCES [dbo].[Exotics] ([id])
ALTER TABLE [dbo].[CreditEntryFees]
    ADD CONSTRAINT [FK_CreditEntryFees_Credit] FOREIGN KEY ([credit_id]) REFERENCES [dbo].[Credit] ([id])
ALTER TABLE [dbo].[Credit]
    WITH NOCHECK ADD CONSTRAINT [FK_Credit_Contracts] FOREIGN KEY ([id]) REFERENCES [dbo].[Contracts] ([id])
ALTER TABLE [dbo].[Credit]
    WITH NOCHECK ADD CONSTRAINT [FK_Credit_InstallmentTypes] FOREIGN KEY ([installment_type]) REFERENCES [dbo].[InstallmentTypes] ([id])
ALTER TABLE [dbo].[Credit]
    WITH NOCHECK ADD CONSTRAINT [FK_Credit_Packages] FOREIGN KEY ([package_id]) REFERENCES [dbo].[Packages] ([id])
ALTER TABLE [dbo].[Credit]
    WITH NOCHECK ADD CONSTRAINT [FK_Credit_Temp_FundingLines] FOREIGN KEY ([fundingLine_id]) REFERENCES [dbo].[FundingLines] ([id]) NOT FOR REPLICATION
ALTER TABLE [dbo].[Credit]
    WITH NOCHECK ADD CONSTRAINT [FK_Credit_Users] FOREIGN KEY ([loanofficer_id]) REFERENCES [dbo].[Users] ([id]);


GO
ALTER TABLE [dbo].[Credit] NOCHECK CONSTRAINT [FK_Credit_Users]
ALTER TABLE [dbo].[PersonGroupBelonging]
    WITH NOCHECK ADD CONSTRAINT [FK_PersonGroupBelonging_Persons1] FOREIGN KEY ([person_id]) REFERENCES [dbo].[Persons] ([id])
ALTER TABLE [dbo].[PersonGroupBelonging]
    WITH NOCHECK ADD CONSTRAINT [FK_PersonGroupCorrespondance_Groups] FOREIGN KEY ([group_id]) REFERENCES [dbo].[Groups] ([id])
ALTER TABLE [dbo].[CorporatePersonBelonging]
    ADD CONSTRAINT [FK_CorporatePersonBelonging_Corporates] FOREIGN KEY ([corporate_id]) REFERENCES [dbo].[Corporates] ([id])
ALTER TABLE [dbo].[CorporatePersonBelonging]
    ADD CONSTRAINT [FK_CorporatePersonBelonging_Persons] FOREIGN KEY ([person_id]) REFERENCES [dbo].[Persons] ([id])
ALTER TABLE [dbo].[AdvancedFieldsValues]
    ADD CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFields] FOREIGN KEY ([field_id]) REFERENCES [dbo].[AdvancedFields] ([id])
ALTER TABLE [dbo].[AdvancedFieldsValues]
    ADD CONSTRAINT [FK_AdvancedFieldsValues_AdvancedFieldsLinkEntities] FOREIGN KEY ([entity_field_id]) REFERENCES [dbo].[AdvancedFieldsLinkEntities] ([id])
ALTER TABLE [dbo].[AdvancedFields]
    ADD CONSTRAINT [FK_AdvancedFields_AdvancedFieldsEntities] FOREIGN KEY ([entity_id]) REFERENCES [dbo].[AdvancedFieldsEntities] ([id])
ALTER TABLE [dbo].[AdvancedFields]
    ADD CONSTRAINT [FK_AdvancedFields_AdvancedFieldsTypes] FOREIGN KEY ([type_id]) REFERENCES [dbo].[AdvancedFieldsTypes] ([id])
ALTER TABLE [dbo].[AllowedRoleActions]
    ADD CONSTRAINT [FK_AllowedRoleActions_ActionItems] FOREIGN KEY ([action_item_id]) REFERENCES [dbo].[ActionItems] ([id])
ALTER TABLE [dbo].[AllowedRoleActions]
    ADD CONSTRAINT [FK_AllowedRoleActions_AllowedRoleActions] FOREIGN KEY ([action_item_id], [role_id]) REFERENCES [dbo].[AllowedRoleActions] ([action_item_id], [role_id])
ALTER TABLE [dbo].[AllowedRoleActions]
    ADD CONSTRAINT [FK_AllowedRoleActions_Roles] FOREIGN KEY ([role_id]) REFERENCES [dbo].[Roles] ([id])
ALTER TABLE [dbo].[TrancheEvents]
    ADD CONSTRAINT [FK_TrancheEvents_ContractEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[ContractEvents] ([id])
ALTER TABLE [dbo].[TellerEvents]
    ADD CONSTRAINT [FK_TellerEvents_Tellers] FOREIGN KEY ([teller_id]) REFERENCES [dbo].[Tellers] ([id])
ALTER TABLE [dbo].[LoansLinkSavingsBook]
    ADD CONSTRAINT [FK_LoansLinkSavingsBook_Contracts] FOREIGN KEY ([loan_id]) REFERENCES [dbo].[Contracts] ([id])
ALTER TABLE [dbo].[LoansLinkSavingsBook]
    ADD CONSTRAINT [FK_LoansLinkSavingsBook_SavingContracts] FOREIGN KEY ([savings_id]) REFERENCES [dbo].[SavingContracts] ([id])
ALTER TABLE [dbo].[EntryFees]
    ADD CONSTRAINT [FK_EntryFees_Packages] FOREIGN KEY ([id_product]) REFERENCES [dbo].[Packages] ([id])
ALTER TABLE [dbo].[SavingBookProducts]
    ADD CONSTRAINT [FK_SavingBookProducts_SavingProducts] FOREIGN KEY ([id]) REFERENCES [dbo].[SavingProducts] ([id])
ALTER TABLE [dbo].[SavingProducts]
    WITH NOCHECK ADD CONSTRAINT [FK_SavingProducts_Currencies] FOREIGN KEY ([currency_id]) REFERENCES [dbo].[Currencies] ([id])
ALTER TABLE [dbo].[City]
    ADD CONSTRAINT [FK_City_Districts] FOREIGN KEY ([district_id]) REFERENCES [dbo].[Districts] ([id])
ALTER TABLE [dbo].[StandardBookings]
    ADD CONSTRAINT [FK_StandardBookings_ChartOfAccounts] FOREIGN KEY ([debit_account_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[StandardBookings]
    ADD CONSTRAINT [FK_StandardBookings_ChartOfAccounts1] FOREIGN KEY ([credit_account_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[AmountCycles]
    ADD CONSTRAINT [FK_AmountCycles_Cycles] FOREIGN KEY ([cycle_id]) REFERENCES [dbo].[Cycles] ([id])
ALTER TABLE [dbo].[Districts]
    WITH NOCHECK ADD CONSTRAINT [FK_Districts_Provinces] FOREIGN KEY ([province_id]) REFERENCES [dbo].[Provinces] ([id])
ALTER TABLE [dbo].[SavingsAccountingMovements]
    ADD CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts] FOREIGN KEY ([debit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[SavingsAccountingMovements]
    ADD CONSTRAINT [FK_SavingsAccountingMovements_ChartOfAccounts1] FOREIGN KEY ([credit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[ChartOfAccounts]
    ADD CONSTRAINT [FK_ChartOfAccounts_AccountsCategory] FOREIGN KEY ([account_category_id]) REFERENCES [dbo].[AccountsCategory] ([id])
ALTER TABLE [dbo].[ContractAccountingRules]
    ADD CONSTRAINT [FK_ContractAccountingRules_AccountingRules] FOREIGN KEY ([id]) REFERENCES [dbo].[AccountingRules] ([id])
ALTER TABLE [dbo].[ContractAccountingRules]
    ADD CONSTRAINT [FK_ContractAccountingRules_DomainOfApplications] FOREIGN KEY ([activity_id]) REFERENCES [dbo].[EconomicActivities] ([id])
ALTER TABLE [dbo].[ContractAccountingRules]
    ADD CONSTRAINT [FK_ContractAccountingRules_Packages] FOREIGN KEY ([loan_product_id]) REFERENCES [dbo].[Packages] ([id])
ALTER TABLE [dbo].[ContractAccountingRules]
    ADD CONSTRAINT [FK_ContractAccountingRules_SavingProducts] FOREIGN KEY ([savings_product_id]) REFERENCES [dbo].[SavingProducts] ([id])
ALTER TABLE [dbo].[AccountingRules]
    ADD CONSTRAINT [FK_AccountingRules_ChartOfAccounts] FOREIGN KEY ([debit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[AccountingRules]
    ADD CONSTRAINT [FK_AccountingRules_ChartOfAccounts1] FOREIGN KEY ([credit_account_number_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[AccountingRules]
    WITH NOCHECK ADD CONSTRAINT [FK_AccountingRules_EventAttributes] FOREIGN KEY ([event_attribute_id]) REFERENCES [dbo].[EventAttributes] ([id]) NOT FOR REPLICATION
ALTER TABLE [dbo].[AccountingRules]
    WITH NOCHECK ADD CONSTRAINT [FK_AccountingRules_EventTypes] FOREIGN KEY ([event_type]) REFERENCES [dbo].[EventTypes] ([event_type]) NOT FOR REPLICATION
ALTER TABLE [dbo].[SavingEvents]
    ADD CONSTRAINT [FK_SavingEvents_SavingContracts] FOREIGN KEY ([contract_id]) REFERENCES [dbo].[SavingContracts] ([id])
ALTER TABLE [dbo].[SavingEvents]
    ADD CONSTRAINT [FK_SavingEvents_Tellers] FOREIGN KEY ([teller_id]) REFERENCES [dbo].[Tellers] ([id])
ALTER TABLE [dbo].[SavingEvents]
    ADD CONSTRAINT [FK_SavingEvents_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
ALTER TABLE [dbo].[Corporates]
    ADD CONSTRAINT [FK_Corporates_DomainOfApplications] FOREIGN KEY ([activity_id]) REFERENCES [dbo].[EconomicActivities] ([id])
ALTER TABLE [dbo].[Packages]
    WITH NOCHECK ADD CONSTRAINT [FK_Packages_Currencies] FOREIGN KEY ([currency_id]) REFERENCES [dbo].[Currencies] ([id])
ALTER TABLE [dbo].[Packages]
    WITH NOCHECK ADD CONSTRAINT [FK_Packages_Cycles] FOREIGN KEY ([cycle_id]) REFERENCES [dbo].[Cycles] ([id]);


GO
ALTER TABLE [dbo].[Packages] NOCHECK CONSTRAINT [FK_Packages_Cycles]
ALTER TABLE [dbo].[Packages]
    WITH NOCHECK ADD CONSTRAINT [FK_Packages_Exotics] FOREIGN KEY ([exotic_id]) REFERENCES [dbo].[Exotics] ([id]);


GO
ALTER TABLE [dbo].[Packages] NOCHECK CONSTRAINT [FK_Packages_Exotics]
ALTER TABLE [dbo].[Packages]
    WITH NOCHECK ADD CONSTRAINT [FK_Packages_InstallmentTypes] FOREIGN KEY ([installment_type]) REFERENCES [dbo].[InstallmentTypes] ([id]);


GO
ALTER TABLE [dbo].[Packages] NOCHECK CONSTRAINT [FK_Packages_InstallmentTypes]
ALTER TABLE [dbo].[Projects]
    ADD CONSTRAINT [FK_Projects_Tiers] FOREIGN KEY ([tiers_id]) REFERENCES [dbo].[Tiers] ([id])
ALTER TABLE [dbo].[SavingContracts]
    ADD CONSTRAINT [FK_SavingContracts_Tiers] FOREIGN KEY ([tiers_id]) REFERENCES [dbo].[Tiers] ([id])
ALTER TABLE [dbo].[SavingContracts]
    ADD CONSTRAINT [FK_SavingContracts_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
ALTER TABLE [dbo].[SavingContracts]
    ADD CONSTRAINT [FK_Savings_SavingProducts] FOREIGN KEY ([product_id]) REFERENCES [dbo].[SavingProducts] ([id])
ALTER TABLE [dbo].[Persons]
    ADD CONSTRAINT [FK_Persons_Banks] FOREIGN KEY ([personalBank_id]) REFERENCES [dbo].[Banks] ([id])
ALTER TABLE [dbo].[Persons]
    ADD CONSTRAINT [FK_Persons_Banks1] FOREIGN KEY ([businessBank_id]) REFERENCES [dbo].[Banks] ([id])
ALTER TABLE [dbo].[Persons]
    WITH NOCHECK ADD CONSTRAINT [FK_Persons_DomainOfApplications] FOREIGN KEY ([activity_id]) REFERENCES [dbo].[EconomicActivities] ([id])
ALTER TABLE [dbo].[Persons]
    WITH NOCHECK ADD CONSTRAINT [FK_Persons_Tiers] FOREIGN KEY ([id]) REFERENCES [dbo].[Tiers] ([id]);


GO
ALTER TABLE [dbo].[Persons] NOCHECK CONSTRAINT [FK_Persons_Tiers]
ALTER TABLE [dbo].[EconomicActivities]
    WITH NOCHECK ADD CONSTRAINT [FK_DomainOfApplications_DomainOfApplications] FOREIGN KEY ([parent_id]) REFERENCES [dbo].[EconomicActivities] ([id])
ALTER TABLE [dbo].[FundingLineEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_FundingLineEvents_FundingLines] FOREIGN KEY ([fundingline_id]) REFERENCES [dbo].[FundingLines] ([id]) NOT FOR REPLICATION
ALTER TABLE [dbo].[FundingLines]
    WITH NOCHECK ADD CONSTRAINT [FK_FundingLines_Currencies] FOREIGN KEY ([currency_id]) REFERENCES [dbo].[Currencies] ([id])
ALTER TABLE [dbo].[ContractEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_ContractEvents_Contracts] FOREIGN KEY ([contract_id]) REFERENCES [dbo].[Contracts] ([id])
ALTER TABLE [dbo].[ContractEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_ContractEvents_LoanInterestAccruingEvents] FOREIGN KEY ([id]) REFERENCES [dbo].[LoanInterestAccruingEvents] ([id]) NOT FOR REPLICATION;


GO
ALTER TABLE [dbo].[ContractEvents] NOCHECK CONSTRAINT [FK_ContractEvents_LoanInterestAccruingEvents]
ALTER TABLE [dbo].[ContractEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_ContractEvents_Tellers] FOREIGN KEY ([teller_id]) REFERENCES [dbo].[Tellers] ([id])
ALTER TABLE [dbo].[ContractEvents]
    WITH NOCHECK ADD CONSTRAINT [FK_ContractEvents_Users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[Users] ([id])
ALTER TABLE [dbo].[Tellers]
    ADD CONSTRAINT [FK_Tellers_Branches] FOREIGN KEY ([branch_id]) REFERENCES [dbo].[Branches] ([id])
ALTER TABLE [dbo].[Tellers]
    ADD CONSTRAINT [FK_Tellers_ChartOfAccounts] FOREIGN KEY ([account_id]) REFERENCES [dbo].[ChartOfAccounts] ([id])
ALTER TABLE [dbo].[Tellers]
    ADD CONSTRAINT [FK_Tellers_Currencies] FOREIGN KEY ([currency_id]) REFERENCES [dbo].[Currencies] ([id])
ALTER TABLE [dbo].[Tiers]
    ADD CONSTRAINT [FK_Tiers_Branches] FOREIGN KEY ([branch_id]) REFERENCES [dbo].[Branches] ([id])
ALTER TABLE [dbo].[Tiers]
    WITH NOCHECK ADD CONSTRAINT [FK_Tiers_Corporates] FOREIGN KEY ([id]) REFERENCES [dbo].[Corporates] ([id]);


GO
ALTER TABLE [dbo].[Tiers] NOCHECK CONSTRAINT [FK_Tiers_Corporates]
ALTER TABLE [dbo].[Tiers]
    WITH NOCHECK ADD CONSTRAINT [FK_Tiers_Districts] FOREIGN KEY ([district_id]) REFERENCES [dbo].[Districts] ([id])
ALTER TABLE [dbo].[Tiers]
    WITH NOCHECK ADD CONSTRAINT [FK_Tiers_Districts1] FOREIGN KEY ([secondary_district_id]) REFERENCES [dbo].[Districts] ([id])
COMMIT TRANSACTION
Feature: PlanAssignments
	Assigning exercise plans to the patients

@mytag
Scenario Outline: Add exercise to a plan and assign plan to the patient
	Given user is country selection page
	When user selects 'us'
	When user adds exercise to the plan
		| Exercise   |
		| <Exercise> |
	When user assigns plan to a 'Demo-patient' patient
	Then plan is assigned to a 'Demo-patient' patient

	Examples: 
	| Exercise |
	| Bird dog |
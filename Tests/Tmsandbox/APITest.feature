Feature: TMSandBox API Tests

Scenario Outline: Validate Category Details
	Given I set the API baseURL to 'https://api.tmsandbox.co.nz'
	When I get the details for Category ID: <CategoryID>
	Then I verify that the 'Name' JSON property has a value of '<Name>'
	And I verify that the 'CanRelist' JSON property has a value of '<CanRelist>'
	And I verify that the list of Promotions has an element named '<PromotionName>' with a Description: '<PromotionDescription>'

	Examples:
	| CategoryID  | Name           | CanRelist   | PromotionName | PromotionDescription        |
	| 6327        | Carbon credits | True        | Gallery       | Good position in category   |
	| 6328        | Badges         | False       | Feature       | Better position in category |
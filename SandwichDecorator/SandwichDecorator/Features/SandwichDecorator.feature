Feature: Sandwich Bread

@BLTSandwich @WhiteBread
Scenario: Cost of BLT sandwich on white bread
    When a BLT sandwich on white bread is ordered
    Then the sandwich will cost $4.50
    And the sandwich is described as "BLT sandwich on white bread"

@BLTSandwich @WheatBread
Scenario: Cost of BLT sandwich on wheat bread
    When a BLT sandwich on wheat bread is ordered
    Then the sandwich will cost $4.75
    And the sandwich is described as "BLT sandwich on wheat bread"


@BLTSandwich @RyeBread
Scenario: Cost of BLT sandwich on rye bread
    When a BLT sandwich on rye bread is ordered
    Then the sandwich will cost $5.00
    And the sandwich is described as "BLT sandwich on rye bread"


@PBJSandwich @WhiteBread
Scenario: Cost of PBJ sandwich on white bread
    When a PBJ sandwich on white bread is ordered
    Then the sandwich will cost $2.75
    And the sandwich is described as "PBJ sandwich on white bread"


@PBJSandwich @WheatBread
Scenario: Cost of PBJ sandwich on wheat bread
    When a PBJ sandwich on wheat bread is ordered
    Then the sandwich will cost $3.00
    And the sandwich is described as "PBJ sandwich on wheat bread"

@PBJSandwich @RyeBread
Scenario: Cost of PBJ sandwich on rye bread
    When a PBJ sandwich on rye bread is ordered
    Then the sandwich will cost $3.25
    And the sandwich is described as "PBJ sandwich on rye bread"

@ChickenSandwich @WhiteBread
Scenario: Cost of chicken sandwich on white bread
    When a chicken sandwich on white bread is ordered
    Then the sandwich will cost $4.00
    And the sandwich is described as "Chicken sandwich on white bread"


@ChickenSandwich @WheatBread
Scenario: Cost of chicken sandwich on wheat bread
    When a chicken sandwich on wheat bread is ordered
    Then the sandwich will cost $4.25
    And the sandwich is described as "Chicken sandwich on wheat bread"

@ChickenSandwich @RyeBread
Scenario: Cost of chicken sandwich on rye bread
    When a chicken sandwich on rye bread is ordered
    Then the sandwich will cost $4.50
    And the sandwich is described as "Chicken sandwich on rye bread"

@Toppings
Scenario: Shredded chicken on white + cheese + cheese + cheese = $6.25
    When a chicken sandwich on white bread is ordered
    And customer orders cheese
    Then the sandwich will cost $6.25
    And the sandwich is described as "Chicken sandwich on white bread + cheese + cheese + cheese "

@Toppings
Scenario: Shredded chicken on rye + cheese + lettuce + lettuce + lettuce + tomato + bacon = $7.00
    When a chicken sandwich on rye bread is ordered
    And customer orders cheese
    And customer orders lettuce
    And customer orders lettuce
    And customer orders lettuce
    And customer orders tomato
    And customer orders bacon
    Then the sandwich will cost $7.00
    And the sandwich is described as "Chicken sandwich on rye bread + cheese + lettuce + lettuce + lettuce + tomato + bacon"

@Toppings
Scenario: BLT sandwich on rye + cheese + bacon + bacon + bacon + bacon = $8.75
    When a BLT sandwich on wheat bread is ordered
    And customer orders cheese
    And customer orders bacon
    And customer orders bacon
    And customer orders bacon
    And customer orders bacon
    Then the sandwich will cost $8.75
    And the sandwich is described as "BLT sandwich on rye + cheese + bacon + bacon + bacon + bacon"
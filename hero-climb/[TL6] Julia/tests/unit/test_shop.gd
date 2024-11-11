extends GutTest


var HUDFactory = load("res://[TL6] Julia/scripts/HUD/HUDFactory.cs").new()
var ShopElementFactory = load("res://[TL6] Julia/scripts/HUD/ShopElementFactory.cs").new()

var player
var shop

func before_all():
	player = PlayerGlobal.MakeCharacter(0);

func after_each():
	shop.queue_free()
	pass 

func after_all():
	player.queue_free()

func test_factory_generation():
	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	assert_eq(shop.GetContainer().get_child_count(), 4)

func test_basic_buying():
	ShopElementFactory.Reset(0)

	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var output = shop.elements[0].Buy(100)

	# test basic buying
	assert_lt(output, 100)

func test_price_increase():
	ShopElementFactory.Reset(0)

	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var output = shop.elements[0].Buy(100)
	
	var difference = 100 - output

	# test price increase
	var output2 = shop.elements[0].Buy(100)

	var difference2 = 100 - output2

	assert_lt(difference, difference2)

func test_storage():
	ShopElementFactory.Reset(0)
	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var output = shop.elements[0].Buy(100)
	var difference = 100 - output

	shop.queue_free();

	# wait for queue_free
	await wait_seconds(2)

	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var output2 = shop.elements[0].Buy(100)
	var difference2 = 100 - output2

	assert_lt(difference, difference2)

func test_too_little_money():
	ShopElementFactory.Reset(0)
	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var output = shop.elements[0].Buy(5)
	var difference = 5 - output

	assert_eq(difference, 0)

func test_buying_until_too_low():
	ShopElementFactory.Reset(0)
	shop = HUDFactory.GameShop()
	get_tree().root.add_child(shop)

	var money = 100

	while (true):
		var output = shop.elements[0].Buy(money)
		var difference = money - output

		if (difference == 0): 
			break

		money = output

	assert_eq(shop.elements[0].Buy(money), money)

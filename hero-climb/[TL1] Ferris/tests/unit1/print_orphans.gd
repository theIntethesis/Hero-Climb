extends GutHookScript

func run():
	# Note, this will node will be included in the stray node list.
	var n = Node.new()
	n.print_stray_nodes()
	n.free()

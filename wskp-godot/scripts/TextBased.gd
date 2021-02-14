extends Control

var all_locations = [
	"cockpit",
	"cabin"
]

var current_location = all_locations[0]

var locations = {
	cockpit = "A dark [color=#23e87c]cockpit[/color]. You see several meters and red [color=#223553]button[/color]. There's a slight humming sound.",
	cabin = "Storage area. It looks like its well maintained. It appears to be spotless."
}

var command = false

func _physics_process(delta):
	$location.text = current_location
	

func _on_LineEdit_text_entered(new_text):
	$LineEdit.text = ""
	
	if command == false:
		$Background/TextArea.bbcode_text += new_text
	else:
		pass # Replace with function body.
	
	if new_text == "look":
		if current_location == all_locations[0]:
			$Background/TextArea.bbcode_text += locations.cockpit + "\n"
		elif current_location == all_locations[1]:
			$Background/TextArea.bbcode_text += locations.cabin + "\n"
	elif new_text == "go to " + "cabin":
		current_location = all_locations[1]
		$Background/TextArea.bbcode_text =  ""
		

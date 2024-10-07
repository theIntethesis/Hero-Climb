shader_type canvas_item;

uniform float lod: hint_range(0.0, 10.0) = 0.0;
uniform sampler2D SCREEN_TEXTURE: hint_screen_texture, filter_linear_mipmap;
uniform vec4 tint: source_color;

void fragment() {
	vec4 color = texture(SCREEN_TEXTURE, SCREEN_UV, lod);

	COLOR = vec4(mix(color.rgb,tint.rgb, tint.a), 1.0);
}
#version 330 core

struct DirLight {
	vec3 direction;

	vec3 ambient;
	vec3 diffuse;
	vec3 specular;
};

uniform DirLight dirLight;

in vec2 TexCoords;
in vec3 Normal;

out vec4 FragColor;

void main()
{
    vec3 norm = normalize(Normal);
	float intensity = dot(-dirLight.direction, norm);

    vec3 result;

	if (intensity > 0.99)
		result = vec3(0.8, 0.6, 0.35);
	else if (intensity > 0.5)
		result = vec3(0.67, 0.4, 0.26);
	else if (intensity > 0.25)
		result = vec3(0.4, 0.24, 0.17);
	else
		result = vec3(0.12, 0.07, 0.05);

	result += dirLight.ambient;

    FragColor = vec4(result, 1.0);
}
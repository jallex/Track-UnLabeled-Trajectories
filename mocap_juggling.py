import bpy

for tracker in bpy.data.objects:
    if tracker.type == 'EMPTY':
        bpy.ops.object.armature_add(enter_editmode=False, location=tracker.matrix_world.translation)
        new_armature = bpy.context.selected_objects[0]
        new_armature.parent = tracker
        bpy.ops.mesh.primitive_uv_sphere_add(radius=0.02, enter_editmode=False, location=tracker.matrix_world.translation)
        new_sphere = bpy.context.selected_objects[0]
        new_sphere.parent = new_armature
        

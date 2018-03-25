using System.Collections;
using System.Collections.Generic;
using UnityEditor;
/// <summary>
/// Provides a way of interacting with the contents of the skillsheet for each character. Normally the contents of a List are not accessible within the editor.
/// </summary>

[CustomEditor(typeof(SkillSheet))]
public class SkillSheetEditor : Editor
{
    bool showSkills = true;
    public override void OnInspectorGUI()
    {
        SkillSheet myTarget = (SkillSheet)target;
        showSkills = EditorGUILayout.Foldout(showSkills, "Expand", true); //Hides the controls behind a Foldout UI element to preserve space
        if (showSkills)
        {
            foreach(CascadiaSkill casSkill in myTarget.mySkills) 
            {
                EditorGUILayout.LabelField(casSkill.skillName.ToUpper());
                //EditorGUILayout.LabelField("Current Value");
                casSkill.skillValue = EditorGUILayout.IntSlider(casSkill.skillValue, 0, 100); //sets the CascadiaSkill to the slider value


                //casSkill.skillValue = EditorGUILayout.IntField(casSkill.skillValue);
                //EditorGUILayout.LabelField("Lower Bound");
                //casSkill.lowBound = EditorGUILayout.IntField(casSkill.lowBound);
                //EditorGUILayout.LabelField("Upper Bound");
                //casSkill.highBound = EditorGUILayout.IntField(casSkill.highBound);
                EditorGUILayout.Space();
                
            }
        }
        DrawDefaultInspector();

    }

}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelBuilder : EditorWindow
{
    // [SerializeField] private GameObject objPrefab;

    private Vector3 prevPosition;
    private bool doSnap = true;
    private float snapValue = 1;
 
    [MenuItem( "Tools/Level Builder %_l" )]
    public static void Init()
    {
        var window = (LevelBuilder)EditorWindow.GetWindow( typeof( LevelBuilder ) );
        window.maxSize = new Vector2( 200, 100 );
    }
 
// Create all the UI elements in the level builder editor.
    public void OnGUI()
    {
        doSnap = EditorGUILayout.Toggle( "Auto Snap", doSnap );
        snapValue = EditorGUILayout.FloatField( "Snap Value", snapValue );
       
        EditorGUILayout.LabelField("Block Elements");
        if (GUILayout.Button("Create Block"))
            createBlock();         
    }

    public void Update()
    {
        if ( doSnap
            && !EditorApplication.isPlaying
            && Selection.transforms.Length > 0
            && Selection.transforms[0].position != prevPosition )
        {
            // make sure the snapvalue is not zero
            if (snapValue <= 0) snapValue = 0.001f;
            
            // do the snap
            Snap();
            prevPosition = Selection.transforms[0].position;
        }
    }

    private void createBlock() {
        //Instantiate(objPrefab, Vector3.zero, Quaternion.identity);
    }

    private void Snap()
    {
        // Transforming every object according to its snap value
        foreach ( var transform in Selection.transforms )
        {
            var t = transform.transform.position;
            t.x = Round( t.x );
            t.y = Round( t.y );
            t.z = Round( t.z );
            transform.transform.position = t;
        }
    }
 
    // Calculating the snap value, based on input value which is the coordinate for the objects pivot point
    // divide with the snapValue you gave in the editor windows
    private float Round( float input )
    {
        return snapValue * Mathf.Round( ( input / snapValue ) );
    }
 }


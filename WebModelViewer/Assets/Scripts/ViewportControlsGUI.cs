using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ViewportControlsGUI : MonoBehaviour
{
    public bool enableCameraPerspectives = true;
    public bool enableSkysphereSelection = true;
    public bool enableMaterialSelection = true;

    public bool showControls = true;
    public bool renderGrid = true;
    public bool showAxes = true;

    public GameObject perspectiveCameraRoot = null;
    public GameObject frontCameraRoot = null;
    public GameObject backCameraRoot = null;
    public GameObject leftCameraRoot = null;
    public GameObject rightCameraRoot = null;
    public GameObject topCameraRoot = null;
    public GameObject bottomCameraRoot = null;
    public GameObject axisSystemRoot = null;

    private GameObject activeCamera = null;

    public string skysphereName = "Background";
    private string skysphereNameInternal = null;
    public int skysphereSelection = 0;
    private int previousSkysphereSelection = 0;

    public List<Material> skysphereMaterials = new List<Material>();

    public string materialName = "Material";
    private string materialNameInternal = null;
    public int materialSelection = 0;
    private int previousMaterialelection = 0;

    public GameObject meshesRoot = null;
    private GameObject[] materialMeshes = null;

    private class ViewportControlsGUIComboBox : MonoBehaviour
    {
        private ComboBox comboBox = null;
        private Rect comboBoxRect;
        private int currentSelection = 0;
        private int guiDepth = 0;
        private GUIContent[] comboBoxNames = null;
        private GUIStyle comboBoxStyle = null;

        public bool isVisible = true;

        public ViewportControlsGUIComboBox(Rect comboBoxRect, int startSelection, int guiDepth, GUIContent[] comboBoxNames, GUIStyle comboBoxStyle)
        {
            this.SetComboBoxData(comboBoxRect, startSelection, guiDepth, comboBoxNames, comboBoxStyle);
        }

        public void SetComboBoxData(Rect comboBoxRect, int startSelection, int guiDepth, GUIContent[] comboBoxNames, GUIStyle comboBoxStyle)
        {
            this.currentSelection = startSelection;
            this.comboBox = new ComboBox(this.currentSelection);
            this.comboBoxRect = comboBoxRect;
            this.guiDepth = guiDepth;
            this.comboBoxNames = comboBoxNames;
            this.comboBoxStyle = comboBoxStyle;
        }

        public int GetCurrentSelection()
        {
            return this.currentSelection;
        }

        public void SetRect(Rect comboBoxRect)
        {
            this.comboBoxRect = comboBoxRect;
        }

        void Start()
        {
        }

        void Update()
        {
        }

        void OnGUI()
        {
            if (isVisible)
            {
                GUI.depth = this.guiDepth;

                this.currentSelection = this.comboBox.List(this.comboBoxRect, this.comboBoxNames[this.currentSelection].text, this.comboBoxNames, this.comboBoxStyle);
            }
        }
    }

    private ViewportControlsGUIComboBox skysphereComboBox = null;
    private ViewportControlsGUIComboBox materialComboBox = null;

    // Use this for initialization
    void Start ()
    {
        if (this.perspectiveCameraRoot)
            this.perspectiveCameraRoot.SetActive(true);

        if (this.frontCameraRoot)
            this.frontCameraRoot.SetActive(false);

        if (this.backCameraRoot)
            this.backCameraRoot.SetActive(false);

        if (this.leftCameraRoot)
            this.leftCameraRoot.SetActive(false);

        if (this.rightCameraRoot)
            this.rightCameraRoot.SetActive(false);

        if (this.topCameraRoot)
            this.topCameraRoot.SetActive(false);

        if (this.bottomCameraRoot)
            this.bottomCameraRoot.SetActive(false);

        this.activeCamera = this.perspectiveCameraRoot;

        List<GUIContent> skysphereNameList = new List<GUIContent>();
        skysphereNameList.Add(new GUIContent("Solid Color"));

        for (int i = 0; i < this.skysphereMaterials.Count; i++)
        {
            skysphereNameList.Add(new GUIContent(this.skysphereMaterials[i].name));
        }

        GUIContent[] skysphereNames = skysphereNameList.ToArray();

        GUIStyle comboBoxStyle = new GUIStyle();
        comboBoxStyle.normal.textColor = Color.white;
        comboBoxStyle.onNormal.textColor = Color.black;
        comboBoxStyle.onNormal.background = new Texture2D(2, 2);
        comboBoxStyle.onHover.background =
        comboBoxStyle.hover.background = new Texture2D(2, 2);
        comboBoxStyle.padding.left =
        comboBoxStyle.padding.right =
        comboBoxStyle.padding.top =
        comboBoxStyle.padding.bottom = 4;

        Color[] textureColor = comboBoxStyle.onNormal.background.GetPixels();
        for (int i = 0; i < textureColor.GetLength(0); i++)
            textureColor[i] = new Color(0.75f, 0.75f, 0.75f, 0.75f);
        comboBoxStyle.onNormal.background.SetPixels(textureColor);
        comboBoxStyle.onNormal.background.Apply();

        textureColor = comboBoxStyle.onHover.background.GetPixels();
        for (int i = 0; i < textureColor.GetLength(0); i++)
            textureColor[i] = new Color(0.95f, 0.95f, 0.95f, 0.75f);
        comboBoxStyle.onHover.background.SetPixels(textureColor);
        comboBoxStyle.onHover.background.Apply();

        this.previousSkysphereSelection = this.skysphereSelection;

        GUIContent[] materialNames = new GUIContent[] { new GUIContent("Empty") };

        if (this.meshesRoot != null)
        {
            List<GUIContent> childMeshNames = new List<GUIContent>();
            List<GameObject> childMeshes = new List<GameObject>();
            for (int i = 0; i < this.meshesRoot.transform.childCount; i++)
            {
                childMeshes.Add(this.meshesRoot.transform.GetChild(i).gameObject);
                childMeshNames.Add(new GUIContent(this.meshesRoot.transform.GetChild(i).gameObject.name));
            }
            this.materialMeshes = childMeshes.ToArray();
            materialNames = childMeshNames.ToArray();

            if (this.materialMeshes.GetLength(0) > this.materialSelection)
                this.materialMeshes[this.materialSelection].SetActive(true);
            else if (this.materialMeshes.GetLength(0) > 0)
            {
                this.materialSelection = 0;
                this.materialMeshes[this.materialSelection].SetActive(true);
            }

            for (int i = 0; i < this.materialMeshes.GetLength(0); i++)
            {
                if (i != this.materialSelection)
                    this.materialMeshes[i].SetActive(false);
            }
        }
        else
            this.enableMaterialSelection = false;

        this.previousMaterialelection = this.materialSelection;

        this.skysphereComboBox = this.gameObject.AddComponent<ViewportControlsGUIComboBox>();
        this.materialComboBox = this.gameObject.AddComponent<ViewportControlsGUIComboBox>();

        this.skysphereComboBox.SetComboBoxData(new Rect(30, 130, 160, 25), this.skysphereSelection, -2, skysphereNames, comboBoxStyle);
        this.materialComboBox.SetComboBoxData(new Rect(30, 190, 160, 25), this.materialSelection, -1, materialNames, comboBoxStyle);

        this.skysphereNameInternal = this.skysphereName + ": ";
        this.materialNameInternal = this.materialName + ": ";

        this.SetSkysphere();
    }

    private void SetSkysphere()
    {
        if (this.skysphereSelection <= 0)
        {
            if (this.activeCamera != null)
            {
                Camera activeCameraComponent = this.activeCamera.GetComponentInChildren<Camera>();
                if (activeCameraComponent != null)
                    activeCameraComponent.clearFlags = CameraClearFlags.SolidColor;
            }
        }
        else
        {
            if (this.activeCamera != null)
            {
                Camera activeCameraComponent = this.activeCamera.GetComponentInChildren<Camera>();
                if (activeCameraComponent != null)
                    activeCameraComponent.clearFlags = CameraClearFlags.Skybox;
            }
            RenderSettings.skybox = this.skysphereMaterials[this.skysphereSelection - 1];
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (this.skysphereComboBox != null)
            this.skysphereSelection = this.skysphereComboBox.GetCurrentSelection();
        if (this.materialComboBox != null)
            this.materialSelection = this.materialComboBox.GetCurrentSelection();

	    if (this.axisSystemRoot != null)
        {
            this.axisSystemRoot.SetActive(this.showAxes);
        }

        if (this.skysphereSelection != this.previousSkysphereSelection)
        {
            this.SetSkysphere();
            this.previousSkysphereSelection = this.skysphereSelection;
        }

        if (this.materialSelection != this.previousMaterialelection)
        {
            if (this.materialMeshes != null && this.materialMeshes.GetLength(0) > this.previousMaterialelection)
                this.materialMeshes[this.previousMaterialelection].SetActive(false);
            if (this.materialMeshes != null && this.materialMeshes.GetLength(0) > this.materialSelection)
                this.materialMeshes[this.materialSelection].SetActive(true);
            this.previousMaterialelection = this.materialSelection;
        }
	}

    void OnGUI()
    {
        GUI.depth = 0;

        if (this.skysphereComboBox != null)
            this.skysphereComboBox.isVisible = this.showControls;
        if (this.materialComboBox != null)
            this.materialComboBox.isVisible = this.showControls;

        if (this.showControls && this.enableCameraPerspectives)
        {
            float drawPosX = Screen.width - 100 - 75 - 5;

            GUI.Box(new Rect(drawPosX, 10, 170, 230), "Camera View");
            
            drawPosX = Screen.width - 45 - 100;

            GameObject newCamera = null;

            if (GUI.Button(new Rect(drawPosX, 40, 100, 25), "BACK"))
                newCamera = this.backCameraRoot;

            if (GUI.Button(new Rect(drawPosX, 70, 100, 25), "TOP"))
                newCamera = this.topCameraRoot;

            if (GUI.Button(new Rect(drawPosX, 100, 100, 75), "PERSPECTIVE"))
                newCamera = this.perspectiveCameraRoot;

            if (GUI.Button(new Rect(drawPosX, 180, 100, 25), "BOTTOM"))
                newCamera = this.bottomCameraRoot;

            if (GUI.Button(new Rect(drawPosX, 210, 100, 25), "FRONT"))
                newCamera = this.frontCameraRoot;

            drawPosX = Screen.width - 40;

            if (GUI.Button(new Rect(drawPosX, 70, 25, 135), "R\nI\nG\nH\nT"))
                newCamera = this.rightCameraRoot;

            drawPosX = Screen.width - 100 - 75;

            if (GUI.Button(new Rect(drawPosX, 70, 25, 135), "L\nE\nF\nT"))
                newCamera = this.leftCameraRoot;

            if (newCamera != null)
            {
                if (this.activeCamera != null)
                    this.activeCamera.SetActive(false);

                newCamera.SetActive(true);

                this.activeCamera = newCamera;

                this.SetSkysphere();
            }
        }

        float boxWidth = 200;
        float boxHeight = 500;
        if (!this.showControls)
        {
            boxWidth = 200;
            boxHeight = 65;
        }

        GUI.Box(new Rect(10, 10, boxWidth, boxHeight), "Scene Controls");

        this.showControls = GUI.Toggle(new Rect(15, 40, 100, 25), this.showControls, "Show Controls");

        if (this.showControls)
        {
            this.renderGrid = GUI.Toggle(new Rect(15, 60, 100, 25), this.renderGrid, "Render Grid");
            this.showAxes = GUI.Toggle(new Rect(15, 80, 100, 25), this.showAxes, "Show Axes");

            int currentYPos = 106;


            if (this.skysphereComboBox != null)
            {
                if (this.enableSkysphereSelection)
                {
                    GUI.Label(new Rect(30, currentYPos, 100, 25), this.skysphereNameInternal);
                    this.skysphereComboBox.SetRect(new Rect(30, currentYPos + 25, 160, 25));
                    currentYPos += 60;
                }
                else
                {
                    this.skysphereComboBox.isVisible = false;
                }
            }


            if (this.materialComboBox != null)
            {
                if (this.enableMaterialSelection)
                {
                    GUI.Label(new Rect(30, currentYPos, 100, 25), this.materialNameInternal);
                    this.materialComboBox.SetRect(new Rect(30, currentYPos + 25, 160, 25));
                    currentYPos += 60;
                }
                else
                {
                    this.materialComboBox.isVisible = false;
                }
            }
        }
    }
}

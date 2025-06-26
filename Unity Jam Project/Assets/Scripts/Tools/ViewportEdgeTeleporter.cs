using UnityEngine;
using UnityEngine.Events;

public class ViewportEdgeTeleporter : MonoBehaviour
{
	[Header("Camera")]
	public bool AutoGrabMainCamera;
	public Camera MainCamera;

	[Header("Viewport Bounds")] 
	/// the origin values of the viewport
	public Vector2 ViewportOrigin = new Vector2(0f, 0f);
	/// the dimensions of the viewport
	public Vector2 ViewportDimensions = new Vector2(1f, 1f);
    
	[Header("Teleport Bounds")]
	public Vector2 TeleportOrigin = new Vector2(0f, 0f);
	public Vector2 TeleportDimensions = new Vector2(1f, 1f);

	[Header("Events")]
	public UnityEvent OnTeleport;
    
	protected Vector3 m_viewportPosition;
	protected Vector3 m_newViewportPosition;
	
	protected virtual void Awake()
	{
		Initialization();
	}
	
	protected virtual void Initialization()
	{
		if (AutoGrabMainCamera)
		{
			MainCamera = Camera.main;
		}
	}
	
	protected virtual void DetectEdges()
	{
		m_viewportPosition = MainCamera.WorldToViewportPoint(this.transform.position);
        
		bool teleport = false;
        
		if (m_viewportPosition.x < ViewportOrigin.x) 
		{
			m_newViewportPosition.x = TeleportDimensions.x;
			m_newViewportPosition.y = m_viewportPosition.y;
			m_newViewportPosition.z = m_viewportPosition.z;
			teleport = true;
		}
		else if (m_viewportPosition.x >= ViewportDimensions.x) 
		{
			m_newViewportPosition.x = TeleportOrigin.x;
			m_newViewportPosition.y = m_viewportPosition.y;
			m_newViewportPosition.z = m_viewportPosition.z;
			teleport = true;
		}
		if (m_viewportPosition.y < ViewportOrigin.y) 
		{
			m_newViewportPosition.x = m_viewportPosition.x;
			m_newViewportPosition.y = TeleportDimensions.y;
			m_newViewportPosition.z = m_viewportPosition.z;
			teleport = true;
		}
		else if (m_viewportPosition.y >= ViewportDimensions.y) 
		{
			m_newViewportPosition.x = m_viewportPosition.x;
			m_newViewportPosition.y = TeleportOrigin.y;
			m_newViewportPosition.z = m_viewportPosition.z;
			teleport = true;
		}

		if (teleport)
		{
			OnTeleport?.Invoke();
			this.transform.position = MainCamera.ViewportToWorldPoint(m_newViewportPosition);
		}
	}
	
	protected virtual void Update()
	{
		DetectEdges();
	}

	
}    

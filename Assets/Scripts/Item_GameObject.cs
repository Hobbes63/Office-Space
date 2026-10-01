using UnityEngine;

public class Item_GameObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationAngle; //Serializeable private values just so I can see them while they are changed
    [SerializeField] private float rotationSpeed;

    [SerializeField] private float floatSpeed;
    [SerializeField] private bool goingUp = true;
    [SerializeField] float floatRate;
    [SerializeField] private float floatTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    PlayerManager playerManager;

    [SerializeField] public Item itemDetails;

    [SerializeField] public string itemName;
    [SerializeField] public string itemType;
    [SerializeField] public int itemPotency;
    [SerializeField] public int itemCount;
    [SerializeField] public Sprite itemSprite;

    //Need another field for the item to be described here

    void Start()
    {
        playerManager = GameObject.Find("Player").GetComponent<PlayerManager>();
        
        floatTimer = 0.35f;
        floatSpeed = 0.005f;
        floatRate = 0.90f;

        rotationAngle = new Vector3(0, 1, 0);
        rotationSpeed = 45.0f;

        itemDetails = new Item();

        itemDetails.name = itemName;
        itemDetails.type = itemType;
        itemDetails.potency = itemPotency;
        itemDetails.itemCount = 1;
        itemDetails.itemSprite = itemSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0f)
        {
            
            transform.Rotate(rotationAngle * rotationSpeed, rotationSpeed * Time.deltaTime);

            floatTimer += Time.deltaTime;
            Vector3 moveDir = new Vector3(0.0f, floatSpeed, 0.0f);
            transform.Translate(moveDir);



            if (goingUp && floatTimer >= floatRate)
            {
                goingUp = false;
                floatTimer = 0;
                floatSpeed = -floatSpeed;
            }

            else if (!goingUp && floatTimer >= floatRate)
            {
                goingUp = true;
                floatTimer = 0;
                floatSpeed = -floatSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        //Debug.Log("Item here.");
        if (other.CompareTag("Player"))
         {
            other.gameObject.GetComponent<PlayerManager>().playerInventory.AddToInventory(itemDetails);
            //Debug.Log($"Got {itemDetails.name}!");
            //Destroy(gameObject, 0.2f);
            gameObject.SetActive(false);
        }
    }
}


# YiSpaceWork 
## Task 1 
### Use Case

#### BUG

![](https://i.imgur.com/TTYWyrA.png)

#### Feature Request

![](https://i.imgur.com/ID3fQmi.png)

#### Test Case

![](https://i.imgur.com/TYzqDGC.png)

#### Administrator

![](https://i.imgur.com/DnSECz8.png)


## Task 3

### Data Model
![](https://i.imgur.com/KbSy8T4.png)


### Class Diagram

![](https://i.imgur.com/lUaEixk.png)


###  UI mock up


## Task 4


##### API Request Example

###### HASH
Hash = md5(key1=value1&key2=value2&thirdKey=4E54F0224267BD275F35FF3B33EAB875.... Order by key)

###### Create Task
```json=
{
    "third_name" : "test3rd",
    "Title": "edit function error"
    "hash" : "098F6BCD4621D373CADE4E832627B4F6"
    "Description" : "....."
    ....
}
```

##### API Response

```json=
{
    "status_code": "1",
    "message" : "Success",
    "data":{
        "task_id" : 123,
        "task_url" : "https://task.com.tw/bug123",
        ....
    }
    
}
```

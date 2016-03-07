









DTO，全称Data Transfer Object，数据传输对象。DTO是一个贫血模型




由于DTO需要由WCF传递到Web前台，所以要求这个对象可以序列化，需要标记[DataContract]和[DataMember]两个特性
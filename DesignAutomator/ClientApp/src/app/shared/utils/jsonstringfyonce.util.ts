export function stringifyOnce(obj, replacer, indent){
  var printedObjects = [];
  var printedObjectKeys = [];

  function printOnceReplacer(key, value){
    if ( printedObjects.length > 2000){ // browsers will not print more than 20K, I don't see the point to allow 2K.. algorithm will not be fast anyway if we have too many objects
      return 'object too long';
    }
    var printedObjIndex = -1;
    printedObjects.forEach(function(obj, index){
      if(obj===value){
        printedObjIndex = index;
      }
    });

    if ( key == ''){ //root element
      printedObjects.push(obj);
      printedObjectKeys.push("root");
      return value;
    }

    else if(printedObjIndex != -1 && typeof(value)=="object"){
      if ( printedObjectKeys[printedObjIndex] == "root"){
        return "(pointer to root)";
      }else{
        return "(see " + ((!!value && !!value.constructor) ? value.constructor.name.toLowerCase()  : typeof(value)) + " with key " + printedObjectKeys[printedObjIndex] + ")";
      }
    }else{

      var qualifiedKey = key || "(empty key)";
      printedObjects.push(value);
      printedObjectKeys.push(qualifiedKey);
      if(replacer){
        return replacer(key, value);
      }else{
        return value;
      }
    }
  }
  return JSON.stringify(obj, printOnceReplacer, indent);
};

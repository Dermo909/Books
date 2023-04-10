export function getBody(model?: object): string {

    if (!model) return "";
  
    var propNames = [];
    for (var property in model) {
      if (model.hasOwnProperty(property)) {
        propNames.push(property);
      }
    }
  
    return JSON.stringify(model, propNames);
  }
  
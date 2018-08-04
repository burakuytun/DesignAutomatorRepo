import { Injectable } from '@angular/core';

@Injectable()
export class NamingSettingsService {

  //declare the dictionaries for drag and drop naming setup
  doorComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Document no.', '01'],
    ['Cluster', 'CLUSTER'],
    ['Controller', 'Controller']
  ];

  readerComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Door ref', 'A-01-001'],
    ['Nickname', 'NICK'],
    ['Document no.', '01'],
    ['Cluster', 'CLUSTER'],
    ['Controller', 'Controller'],
    ['Board name', 'ACM'],
    ['Board no.', '1'],
    ['Reader ref.', 'RDR'],
    ['Reader no.', '02'],
    ['Reader entry/exit', 'Entry']
  ];

  inputComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Door ref', 'A-01-001'],
    ['Nickname', 'NICK'],
    ['Document no.', '01'],
    ['Controller', 'Controller'],
    ['Board name', 'ACM'],
    ['Board no.', '1'],
    ['Input ref.', 'IN'],
    ['Input no.', '02'],
    ['Cluster', 'CLUSTER']
  ];

  outputComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Door ref', 'A-01-001'],
    ['Nickname', 'NICK'],
    ['Document no.', '01'],
    ['Controller', 'Controller'],
    ['Board name', 'ACM'],
    ['Board no.', '1'],
    ['Output ref.', 'OUT'],
    ['Output no.', '02'],
    ['Cluster', 'CLUSTER']
  ];

  remoteModuleInputComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Door ref', 'A-01-001'],
    ['Nickname', 'NICK'],
    ['Document no.', '01'],
    ['Controller', 'Controller'],
    ['Board name', 'ACM'],
    ['Board no.', '1'],
    ['Input ref.', 'IN'],
    ['Input no.', '02'],
    ['Cluster', 'CLUSTER'],
    ['RS485 port name', 'P'],
    ['RS485 port no.', '3'],
    ['RM name', 'RM'],
    ['RM no', '4'],
    ['RS485 port name', 'P'],
    ['RM input name', 'RI'],
    ['RM input no', '5'],
    ['RM no', '4']
  ];

  remoteModuleOutputComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Door ref', 'A-01-001'],
    ['Nickname', 'NICK'],
    ['Document no.', '01'],
    ['Controller', 'Controller'],
    ['Board name', 'ACM'],
    ['Board no.', '1'],
    ['Output ref.', 'OUT'],
    ['Output no.', '2'],
    ['Cluster', 'CLUSTER'],
    ['RS485 port name', 'P'],
    ['RS485 port no.', '3'],
    ['RM name', 'RM'],
    ['RM no', '4'],
    ['RS485 port name', 'P'],
    ['RM output name', 'RI'],
    ['RM output no', '5'],
    ['RM no', '4']
  ];

  clusterComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Document no.', '01'],
    ['Cluster', 'CLUSTER'],
  ];

  controllerComponents = [
    ['Seperator', '-'],
    ['Space', ' '],
    ['Prefix', 'CO-BC-BT'],
    ['Document no.', '01'],
    ['Controller', 'CONTROLLER'],
  ];

  initialGenericComponents = [
    ['Prefix', 'CO-BC-BT'],
    ['Seperator', '-'],
    ['Door ref', 'A-01-001'],
    ['Seperator', '-'],
    ['Nickname', 'NICK']
  ];

  initialReaderComponents = [
    ['Prefix', 'CO-BC-BT'],
    ['Seperator', '-'],
    ['Door ref', 'A-01-001'],
    ['Seperator', '-'],
    ['Nickname', 'NICK'],
    ['Seperator', '-'],
    ['Reader entry/exit', 'Entry']
  ];

  initialClusterComponents = [
    ['Prefix', 'CO-BC-BT'],
    ['Seperator', '-'],
    ['Cluster', 'CLUSTER']
  ];

  initialControllerComponents = [
    ['Prefix', 'CO-BC-BT'],
    ['Seperator', '-'],
    ['Controller', 'CONTROLLER'],
    ['Seperator', '-'],
    ['Document no.', '01']
  ];

  constructor() {
  }

  getComponents(componentType: string) {
    if (componentType === 'door')
      return Object.assign([], this.doorComponents);
    else if (componentType === 'reader')
      return Object.assign([], this.readerComponents);
    else if (componentType === 'input')
      return Object.assign([], this.inputComponents);
    else if (componentType === 'output')
      return Object.assign([], this.outputComponents);
    else if (componentType === 'rmInput')
      return Object.assign([], this.remoteModuleInputComponents);
    else if (componentType === 'rmOutput')
      return Object.assign([], this.remoteModuleOutputComponents);
    else if (componentType === 'controller')
      return Object.assign([], this.controllerComponents);
    else if (componentType === 'cluster')
      return Object.assign([], this.clusterComponents);

    return null;
  }

  getExampleText(components: string[][]) {
    var sampleText = '';
    for (let component of components) {
      sampleText = `${sampleText}${component[1]}`;
    }
    return sampleText;
  }

  getInitialSelected(componentType: string) {

    if (componentType === 'door' ||
      componentType === 'input' ||
      componentType === 'output' ||
      componentType === 'rmInput' ||
      componentType === 'rmOutput')
      return Object.assign([], this.initialGenericComponents);
    else if (componentType === 'reader')
      return Object.assign([], this.initialReaderComponents);
    else if (componentType === 'controller')
      return Object.assign([], this.initialControllerComponents);
    else if (componentType === 'cluster')
      return Object.assign([], this.initialClusterComponents);
  }
}
